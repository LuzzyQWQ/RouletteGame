using Argali.Module.Singleton;
using System.Collections.Generic;
using UnityEngine;

namespace Argali.UI.Pop
{
    // 弹窗管理器
    // 里面都是单例
    public class PopPanelManager : Singleton<PopPanelManager>
    {
        private List<IPopPanel> popPanels = new();

        // 弹窗顺序列表 最高 -> 最低
        private List<IPopPanel> popOrderList = new();

        // 最高层级
        private readonly int maxLayer = 5000;

        private readonly int addLayer = 20;

        // 最高Layer
        private int topLayer
        {
            get
            {
                if (popOrderList.Count > 0)
                    return popOrderList[0].GetSortLayer();
                return GetSceneTopLayer();
            }
        }


        /// <summary>
        /// 获得最上层的层数
        /// </summary>
        /// <returns></returns>
        public int GetTopLayer()
        {
            if (popOrderList.Count == 0)
            {
                return 0;
            }
            return topLayer;
        }
        #region 增加减少PopPanel

        public void AddPopPanelItem(IPopPanel popPanelItem)
        {
            if (!popPanels.Contains(popPanelItem))
            {
                popPanels.Add(popPanelItem);
            }
        }

        public void RemovePopPanelItem(IPopPanel popPanelItem)
        {
            popPanels.Remove(popPanelItem);
        }

        #endregion

        /// <summary>
        /// 弹出相应弹窗
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T OpenPopPanel<T>(bool forceFade = false) where T : IPopPanel
        {
            IPopPanel popPanel = null;
            foreach (IPopPanel panel in popOrderList)
            {
                if (panel is T)
                {
                    TopOrder<T>();
                    return (T)popOrderList[0];
                }
            }

            // 如果没有弹出
            foreach (IPopPanel panel in popPanels)
            {
                if (panel is T)
                {
                    popPanel = panel;
                }
            }

            if (popPanel == null)
            {
                UnityEngine.Debug.LogError("未找到 " + typeof(T));
                return default;
            }

            if (forceFade && popPanel is BasePopPanel basePopPanel)
            {
                basePopPanel.ActiveFade(true);
            }

            popPanel.SetSortLayer(topLayer + addLayer);
            popOrderList.Insert(0, popPanel);
            popPanel.Pop();
            return (T)popPanel;
        }

        /// <summary>
        /// 关闭弹窗
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void ClosePopPanel<T>() where T : IPopPanel
        {
            for (int i = 0; i < popOrderList.Count; i++)
            {
                if (popOrderList[i] is T)
                {
                    popOrderList[i].Close();
                    popOrderList.RemoveAt(i);
                }
            }
        }

        public T GetPopPanel<T>() where T : IPopPanel, new()
        {
            // 如果没有弹出
            foreach (var item in popPanels)
            {
                if (item is T panel)
                {
                    return panel;
                }
            }

            return default;
        }

        /// <summary>
        /// 获得当前场景最高的SortingOrder
        /// </summary>
        /// <returns></returns>
        private int GetSceneTopLayer()
        {
            var canvasList = FindObjectsOfType<Canvas>();
            int ans = 0;
            foreach (var canvas in canvasList)
            {
                if (ans < canvas.sortingOrder && canvas.sortingOrder < maxLayer)
                    ans = canvas.sortingOrder;
            }

            return ans;
        }

        /// <summary>
        /// 置顶弹窗顺序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private void TopOrder<T>() where T : IPopPanel
        {
            for (int i = 0; i < popOrderList.Count; i++)
            {
                if (popOrderList[i] is T)
                {
                    if (i != 0)
                    {
                        IPopPanel tmp = popOrderList[0];
                        popOrderList[0] = popOrderList[i];
                        popOrderList[i] = tmp;
                        popOrderList[0].SetSortLayer(popOrderList[0].GetSortLayer() + addLayer);
                    }
                }
            }
        }
    }
}

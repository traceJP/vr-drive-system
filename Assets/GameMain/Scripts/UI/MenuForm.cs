using DG.Tweening;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public class MenuForm : UGuiForm
    {
        private ProcedureMenu m_ProcedureMenu;
        
        public void OnClickStartGame(int subjectId)
        {
            Log.Info("subjectId: {0}", subjectId);
            m_ProcedureMenu.StartGame((byte)subjectId);
        }
        
        public void OnButtonHover(RectTransform rectTransform)
        {
            rectTransform.DOScale(new Vector3(1.5F, 1.5F, 1.5F), 0.5F)
                .SetLoops(-1, LoopType.Yoyo);
        }

        public void OnButtonHoverEnd(RectTransform rectTransform)
        {
            rectTransform.DOKill();
            rectTransform.localScale = new Vector3(1F, 1F, 1F);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            m_ProcedureMenu = (ProcedureMenu)userData;
            if (m_ProcedureMenu == null)
            {
                Log.Warning("ProcedureMenu is invalid when open MenuForm.");
            }
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            m_ProcedureMenu = null;
            base.OnClose(isShutdown, userData);
        }

    }
}

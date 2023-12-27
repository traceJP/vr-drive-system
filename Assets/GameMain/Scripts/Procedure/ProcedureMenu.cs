using GameFramework.Event;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain
{
    public class ProcedureMenu : ProcedureBase
    {

        /**
         * 开始游戏 0:未开始  1科目一场景  2科目二场景 3科目三场景
         */
        private byte m_StartGame = 0;
        
        private MenuForm m_MenuForm;
        
        public void StartGame(byte subjectId)
        {
            m_StartGame = subjectId;
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
            
            // 背景音乐
            GameEntry.Sound.PlayMusic("Menu_BGM");
            
            // 打开UI
            GameEntry.UI.OpenUIForm(AssetUtility.GetUIFormAsset("MenuForm"), "Default", 1, true, this);
            
            // TODO 监听 esc 退出事件，打开退出确认框
            
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            if (m_MenuForm != null)
            {
                m_MenuForm.Close(isShutdown);
                m_MenuForm = null;
            }
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            switch (m_StartGame)
            {
                case 1:
                    procedureOwner.SetData<VarString>("NextSceneName", "SubjectOne");
                    ChangeState<ProcedureChangeScene>(procedureOwner);
                    break;
                case 2:
                    procedureOwner.SetData<VarString>("NextSceneName", "SubjectTwo");
                    ChangeState<ProcedureChangeScene>(procedureOwner);
                    break;
                case 3:
                    procedureOwner.SetData<VarString>("NextSceneName", "SubjectThree");
                    ChangeState<ProcedureChangeScene>(procedureOwner);
                    break;
            }
        }
        
        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_MenuForm = (MenuForm)ne.UIForm.Logic;
        }
        
    }
}
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;


namespace GameMain
{
    public class ProcedureLaunch : ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            procedureOwner.SetData<VarString>("NextSceneName", "Menu");
            ChangeState<ProcedureChangeScene>(procedureOwner);
        }
    }
}
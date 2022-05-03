//基础状态接口
public interface IState
{
    void Enter();
    void Exit();
    void LogicUpdate();
    void PhysicUpdate();

}

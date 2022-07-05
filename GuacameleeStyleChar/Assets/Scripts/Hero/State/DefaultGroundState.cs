namespace GuacameleeStyleChar.Character
{
    public abstract class DefaultGroundState : State
    {
        public DefaultGroundState(Hero hero) : base(hero)
        {

        }

        public override void Start()
        {
            Model.JumpsCount = 0;
            Model.IsGrounded.Subscribe(OnGroundStateChanged, false);
        }

        private void OnGroundStateChanged(bool isGrounded)
        {
            if (isGrounded == false)
            {
                Model.JumpsCount++;
                Hero.SetState(new FlyState(Hero));
            }
        }

        public override void Dispose()
        {
            Model.IsGrounded.Unsubscribe(OnGroundStateChanged);
        }
    }
}

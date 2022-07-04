using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    public abstract class State
    {
        protected Hero Hero { get; private set; }

        protected Animator Animator => Hero.Animator;
        protected HeroModel Model => Hero.Model;
        protected Rigidbody2D Rigidbody => Hero.Rigidbody;
        protected HeroMover Mover => Hero.Mover;
        protected HeroConfig Config => Hero.Config;
        protected HeroPhysics Physics => Hero.Physics;
        protected HeroCore Core => Hero.Core;
        protected HeroAppearance Appearance => Hero.Appearance;

        public State(Hero hero)
        {
            Hero = hero;
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Dispose()
        {

        }

        public virtual void TryTakeHit(Vector3 force)
        {
            Core.TakeHit(force);
        }
    }
}
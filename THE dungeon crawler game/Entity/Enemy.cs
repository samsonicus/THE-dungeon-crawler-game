using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace THE_dungeon_crawler_game
{
    public enum Faceing {North,East,South,West}

    public class Enemy : Entity, ICombatEntity, ICollidable
    {
        protected const int visionRange = 700;
        protected Player player;
        protected double lastAttack;
        protected Faceing faceing = Faceing.North;
        protected int health;
        protected float attackRange;
        protected int attackWidth;
        protected float attackDelay;
        protected int attackDamage;
        public int Health
        {
            get
            {
                return health;
            }
            protected set
            {
                if (value <= 0)
                {
                    health = 0;
                    Die();
                    return;
                }
                health = value;
            }
        }

        public Rectangle CollisionBox
        {
            get
            {
                var rect = animationRectanglesSheet[0, currentAnimationIndex];
                rect.Offset(position);
                return rect;
            }
        }
        /// <summary>
        /// Contructor for Enemy without animation.
        /// </summary>
        /// <param name="health">Enemy start health.</param>
        /// <param name="attackRange">The range at which the enemy can attack.</param>
        /// <param name="attackWidth">The width of the attack.</param>
        /// <param name="attackspeed">The amount of attack per second the enemy can perform.</param>
        /// <param name="attackDamage">the amount of damage.</param>
        /// <param name="spriteName">The name of the sprite.</param>
        /// <param name="position">the position at which the enemy starts at.</param>
        /// <param name="speed">The speed at which the enemy can move.</param>
        /// <param name="direction">The direction the enemy starts pointing.</param>
        public Enemy(int health, float attackRange,int attackWidth ,float attackSpeed, int attackDamage, string spriteName, Vector2 position, int speed, Vector2 direction) : base(spriteName, position, speed, direction)
        {
            this.health = health;
            this.attackRange = attackRange;
            this.attackWidth = attackWidth;
            this.attackDamage = attackDamage;
            attackDelay = 1 / attackSpeed;
            player = GameWorld.Player;
        }

        /// <summary>
        /// Constructor for Enemy with spritestrip animation.
        /// </summary>
        /// <param name="health">Enemy start health.</param>
        /// <param name="attackRange">The range at which the enemy can attack.</param>
        /// <param name="attackWidth">The width of the attack.</param>
        /// <param name="attackspeed">The amount of attack per second the enemy can perform.</param>
        /// <param name="attackDamage">the amount of damage.</param>
        /// <param name="frameCount">The amount of frames in the animation.</param>
        /// <param name="animationFPS">The amount of frames to be shown in a second.</param>
        /// <param name="starPosition">the position at which the enemy starts at.</param>
        /// <param name="spriteName">The name of the sprite.</param>
        /// <param name="speed">The speed at which the enemy can move.</param>
        /// <param name="direction">The direction the enemy starts pointing.</param>
        public Enemy(int health, float attackRange, int attackWidth,float attackspeed,int attackDamage, int frameCount, float animationFPS, Vector2 starPosition, string spriteName, int speed, Vector2 direction) : base(frameCount, animationFPS, starPosition, spriteName, speed, direction)
        {
            this.health = health;
            this.attackRange = attackRange;
            this.attackWidth = attackWidth;
            this.attackDamage = attackDamage;
            attackDelay = 1 / attackspeed;
            player = GameWorld.Player;
        }

        /// <summary>
        /// Gets called each frame.
        /// </summary>
        /// <param name="gameTime">GameTime from the game.</param>
        public override void Update(GameTime gameTime)
        {
            SimpleAI(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// Simpel AI that calcualtes and performs the actions of the enemy.
        /// </summary>
        protected virtual void SimpleAI(GameTime gameTime)
        {
            LookAtPlayer(player.Position);
            float playerDist = DistToPlayer(player.Position);
            if (playerDist < visionRange)
            {
                Move(gameTime);
            }
            if ( playerDist <= attackRange && lastAttack + attackDelay <= gameTime.TotalGameTime.TotalSeconds)
            {
                Attack();
                lastAttack = (float)gameTime.TotalGameTime.TotalSeconds;
            }
        }

        /// <summary>
        /// Sets the direction to point at player.
        /// </summary>
        /// <param name="playerPos">The position of the player the Enemy will look at.</param>
        protected void LookAtPlayer(Vector2 playerPos)
        {
            eDirection = playerPos - position;

            eDirection.Normalize();
            if(eDirection.Y < -0.5f)
            {
                faceing = Faceing.North;
            }
            else if(eDirection.X > 0.5f)
            {
                faceing = Faceing.East;
            }
            else if(eDirection.Y > 0.5f)
            {
                faceing = Faceing.South;
            }
            else
            {
                faceing = Faceing.West;
            }
        }

        /// <summary>
        /// Calculates the distance between the enemy and the player.
        /// </summary>
        /// <param name="playerPos">The position of the player.</param>
        /// <returns>Returns the distance between the player and the enemy.</returns>
        protected float DistToPlayer(Vector2 playerPos)
        {
            Vector2 temp = playerPos - position;
            return temp.Length();
        }

        /// <summary>
        /// Moves the Enemy in the direction it's facings.
        /// </summary>
        /// <param name="gameTime">GameTime object.</param>
        protected void Move(GameTime gameTime)
        {
            position += eDirection * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        /// <summary>
        /// Does the attack of the enemy.
        /// </summary>
        public virtual void Attack()
        {
            Rectangle attackBox;
            switch (faceing)
            {
                case Faceing.North:
                    attackBox = new Rectangle((int)(position.X + 16 - (attackWidth * 0.5f)), (int)(position.Y - attackRange), attackWidth, (int)attackRange+32);
                    break;
                case Faceing.East:
                    attackBox = new Rectangle((int)(position.X), (int)(position.Y + 16 - (attackWidth * 0.5f)), (int)attackRange+32, attackWidth);
                    break;
                case Faceing.South:
                    attackBox = new Rectangle((int)(position.X + 16 - (attackWidth * 0.5f)), (int)(position.Y), attackWidth, (int)attackRange+32);
                    break;
                case Faceing.West:
                    attackBox = new Rectangle((int)(position.X - attackRange),(int)(position.Y + 16 - (attackWidth * 0.5f)), (int)attackRange+32, attackWidth);
                    break;
                default:
                    return;                    
            }
            if (attackBox.Intersects(player.CollisionBox))
            {
                player.LoseHealth(attackDamage);
            }
        }

        /// <summary>
        /// Gains the enemy life.
        /// </summary>
        /// <param name="lifeGained">The amount of life the enemy gains.</param>
        public virtual void GainHealth(int lifeGained)
        {
            Health += lifeGained;
        }

        /// <summary>
        /// Loses the enemy life.
        /// </summary>
        /// <param name="lifeLost">The amount of life the enemy loses.</param>
        public virtual void LoseHealth(int lifeLost)
        {
            Health -= lifeLost;
        }

        /// <summary>
        /// Removes the Enemy from the GameWorld. 
        /// </summary>
        protected override void Die()
        {
            GameWorld.RemoveGameObject(this);
        }
        public bool IsColliding(ICollidable otherCollidable)
        {
            if (otherCollidable is Projectile || otherCollidable is ObstacleTile)
            {
                return otherCollidable.CollisionBox.Intersects(this.CollisionBox);
            }
            return false;
        }

        public void DoCollision(ICollidable otherCollidable)
        {
            
        }
    }
}


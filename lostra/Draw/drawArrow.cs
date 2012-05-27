using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace lostra
{
    class drawArrow
    {
        public Global global;

        public drawArrow(Global global)
        {
            this.global = global;
        }
        public void Drow()
        {
            global.spriteBatch.Begin();
            global.spriteBatch.Draw(global.resources.getTexture("arrow"), new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);
            global.spriteBatch.End();
        }
    }
}

using System;
using TechTalk.SpecFlow;
using DinoGameTeam;

namespace DinoGameSpecFlow.StepDefinitions
{
    [Binding]
    public class DinoStepDefinitions
    {
        private readonly ScenarioContext context;

        public DinoStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"a dino with position \((.*), (.*)\)")]
        public void GivenADinoWithPosition(double x, double y)
        {
            Dinosaur dino =  new Dinosaur();
            dino.X = x;
            dino.Y = y;

            context.Add("dino", dino);
        }

        [Given(@"an (.*) with position \((.*), (.*)\)")]
        public void GivenAEnemyWithPosition(string enemy, double x, double y)
        {
            IDrawable? enemyObj = null;

            switch (enemy)
            {
                case "large cactus":
                    enemyObj = new Cactus("cactusH.dop");
                    break;
                case "medium cactus":
                    enemyObj = new Cactus("cactusM.dop");
                    break;
                case "small cactus":
                    enemyObj = new Cactus("cactusS.dop");
                    break;
                case "cactus mixed cluster type 1":
                    enemyObj = new Cactus("cactusCluster1.dop");
                    break;
                case "cactus mixed cluster type 2":
                    enemyObj = new Cactus("cactusCluster2.dop");
                    break;
                case "cactus mixed cluster type 3":
                    enemyObj = new Cactus("cactusCluster3.dop");
                    break;
                case "cactus cluster high 2 wide":
                    enemyObj = new Cactus("cactusClusterH2W.dop");
                    break;
                case "cactus cluster medium 2 wide":
                    enemyObj = new Cactus("cactusClusterM2W.dop");
                    break;
                case "cactus cluster small 2 wide":
                    enemyObj = new Cactus("cactusClusterS2W.dop");
                    break;
                case "cactus cluster medium 3 wide":
                    enemyObj = new Cactus("cactusClusterM3W.dop");
                    break;
                case "cactus cluster small 3 wide":
                    enemyObj = new Cactus("cactusClusterS3W.dop");
                    break;
            }

            enemyObj.X = x;
            enemyObj.Y = y;
            context.Add("enemy", enemyObj);
        }

        [When(@"collision is checked")]
        public void WhenCollisionIsChecked()
        {
            bool detected = Game.CheckCollision(context.Get<IDrawable>("dino"), context.Get<IDrawable>("enemy"));
            context.Add("detected", detected);
        }

        [Then(@"collision detected is (.*)")]
        public void ThenCollisionDetectedIs(bool detected)
        {
            context.Get<bool>("detected").Should().Be(detected);
        }


        [Given(@"a score of (.*)")]
        public void GivenAScoreOf(int p0)
        {
            context.Add("Score", p0);
        }

        [When(@"a speed increase is checked")]
        public void WhenASpeedIncreaseIsChecked()
        {
            EnemyManager enemyManager = new();
            enemyManager.Update(context.Get<int>("Score"));
            context.Add("enemyManager", enemyManager);
        }

        [Then(@"an enemies velocity should be (.*)")]
        public void ThenAnEnemiesVelocityShouldBe(int p0)
        {
            IDrawable? enemy = context.Get<EnemyManager>("enemyManager").GetEnemy();
            enemy.Velocity.Should().Be(p0);
        }

    }
}

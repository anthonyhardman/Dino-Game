Feature: Dino
![Calculator](https://sp=ecflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](DinoGameSpecFlow/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario Outline: Collison Checks
	Given a dino with position (<dinoX>, <dinoY>)
	And an <enemyType> with position (<enemyX>, <enemyY>)
	When collision is checked
	Then collision detected is <detected>
	Examples: 
	| dinoX | dinoY | enemyType                    | enemyX | enemyY | detected |
	| 0     | 0     | large cactus                 | 0      | 0      | true     |
	| 0     | 0     | medium cactus                | 0      | 0      | true     |
	| 0     | 0     | small cactus                 | 0      | 0      | true     |
	| 0     | 0     | cactus mixed cluster type 1  | 0      | 0      | true     |
	| 0     | 0     | cactus mixed cluster type 2  | 0      | 0      | true     |
	| 0     | 0     | cactus mixed cluster type 3  | 0      | 0      | true     |
	| 0     | 0     | cactus cluster high 2 wide   | 0      | 0      | true     |
	| 0     | 0     | cactus cluster medium 2 wide | 0      | 0      | true     |
	| 0     | 0     | cactus cluster small 2 wide  | 0      | 0      | true     |
	| 0     | 0     | cactus cluster medium 3 wide | 0      | 0      | true     |
	| 0     | 0     | cactus cluster small 3 wide  | 0      | 0      | true     |
	| 0     | 0     | large cactus                 | 50     | 0      | false    |


Scenario Outline: Enemies Speed Up
	Given a score of <Score>
	When a speed increase is checked
	Then an enemies velocity should be <Velocity>
	Examples: 
	| Score | Velocity |
	| 0     | 80       |
	| 99    | 80       |
	| 100   | 100      |
	| 1000  | 260      |


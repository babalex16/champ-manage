using ChampManage.API.Data;
using ChampManage.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChampManage.API.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ChampManageContext _context;

        public CategoryRepository(ChampManageContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        /*
        public async Task<IEnumerable<Category>> GetCategoriesByIdsAsync(IEnumerable<int> categoryIds)
        {
            return await _context.Categories.Where(c => categoryIds.Contains(c.Id)).ToListAsync();
        }*/

        public void AddCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            _context.Categories.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            _context.Categories.Remove(category);
        }

        public void CreateMatchesForChampionship(int championshipId)
        {
            //assuming validation performed in controller
            var championshipCategories = _context.ChampionshipCategories
                .Include(cc => cc.Category)
                .Where(cc => cc.ChampionshipId == championshipId)
                .ToList();

            var allBracketNodes = new List<BracketNode>();

            foreach (var championshipCategory in championshipCategories)
            {
                var participants = _context.UserCategoryRegistrations
                    .Where(ucr => ucr.CategoryId == championshipCategory.CategoryId)
                    .Select(ucr => ucr.UserId)
                    .ToList();
                if (participants.Count >= 2)
                {
                    allBracketNodes.AddRange(CreateMatchesForCategory(championshipCategory, participants));
                }
            }

            _context.Matches.AddRange(allBracketNodes);
        }

        public List<BracketNode> CreateMatchesForCategory(ChampionshipCategory championshipCategory, List<int> participants)
        {
            int numberOfParticipants = participants.Count;
            int closestPowerOfTwo = FindClosestUpperPowerOfTwo(numberOfParticipants);
            int byeCount = closestPowerOfTwo - numberOfParticipants;
            int orderCounter = 1;

            List<BracketNode> leavesBracketNodes = new List<BracketNode>();

            // Handle BYE fights in the first round
            for (int i = 0; i < byeCount; i++)
            {
                var byeNode = new BracketNode
                {
                    Order = orderCounter++,
                    Participant1Id = participants[i],
                    ChampionshipCategoryId = championshipCategory.Id,
                    IsParticipant1Winner =true, 
                };
                leavesBracketNodes.Add(byeNode);
            }

            // Handle normal fights of first round
            for (int i = byeCount, j = numberOfParticipants - 1; i < j; i++, j--)
            {
                var newNode = new BracketNode
                {
                    Order = orderCounter++,
                    ChampionshipCategoryId = championshipCategory.Id,
                    Participant1Id = participants[i],
                    Participant2Id = participants[j],
                };
                leavesBracketNodes.Add(newNode);
            }

            var allBracketNodes = new List<BracketNode>(leavesBracketNodes);
            //no need to run recursive algorithm if the is only 1 match between 2 people for example
            if (allBracketNodes.Count > 1)
            {
                allBracketNodes.AddRange(BuildNextLayerFromLeaves(championshipCategory, leavesBracketNodes));
            }

            // Sort the list by the Order property
            allBracketNodes = allBracketNodes.OrderBy(node => node.Order).ToList();

            return allBracketNodes;
        }

        private List<BracketNode> BuildNextLayerFromLeaves(ChampionshipCategory championshipCategory, List<BracketNode> currentNodes)
        {
            int matchOrder = currentNodes.Last().Order;  // Get the order of the last element in the received set
            int nextMatchOrder = matchOrder + 1;  // Initialize the order for the next set of matches

            List<BracketNode> nextLayerNodes = new List<BracketNode>();
            List<BracketNode> allNodes = new List<BracketNode>();  // New list to accumulate all nodes

            // Build the next layer of matches
            for (int i = 0; i < currentNodes.Count; i += 2)
            {
                var newMatch = new BracketNode
                {
                    Order = nextMatchOrder++,
                    ChampionshipCategoryId = championshipCategory.Id,
                    LeftChild = currentNodes[i],
                    RightChild = currentNodes[i + 1],
                };
                nextLayerNodes.Add(newMatch);
                allNodes.Add(newMatch);  // Add the new node to the accumulator
            }

            // Check if there are more than one node in the nextLayerNodes list
            if (nextLayerNodes.Count > 1)
            {
                var recursivelyBuiltNodes = BuildNextLayerFromLeaves(championshipCategory, nextLayerNodes);
                allNodes.AddRange(recursivelyBuiltNodes);  // Add nodes from the recursive call to the accumulator
            }

            return allNodes;  // Return all accumulated nodes
        }

        private static int FindClosestUpperPowerOfTwo(int num)
        {   
            if (num <= 0)
            {
                throw new ArgumentException("Input must be a positive integer.");
            }

            int nextPowerOfTwo = 1;
            while (nextPowerOfTwo < num)
            {
                nextPowerOfTwo <<= 1; // Left shift by 1 is equivalent to multiplying by 2
            }

            return nextPowerOfTwo;
        }

        public List<BracketNode> GetMatchesForChampionship(int championshipId)
        {
            var matches = _context.Matches
                .Include(m => m.Participant1)
                .Include(m => m.Participant2)
                .Where(m => m.ChampionshipCategory.ChampionshipId == championshipId)
                .ToList();

            return matches;
        }


        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }

}

namespace ListGroupAndSum
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Material> materiallist = new List<Material>
            {
                new Material("10001", "Fiber", 1, 100),
                new Material("10001", "Fiber", 1, 100),
                new Material("10002", "Fiber", 1, 452),
                new Material("10002", "Fiber", 1, 700),
                new Material("10001", "Fiber", 1, 300)
            };

            GroupMaterials(materiallist);

            Console.ReadLine();
        }

        private static void GroupMaterials(List<Material> materiallist)
        {
            var groupMaterialList = materiallist.GroupBy(t => new { t.ID })
                                                        .Select(grp => new Material
                                                        {
                                                            ID = grp.Key.ID,
                                                            category = grp.First().category,
                                                            count = grp.Count(),
                                                            meters = grp.Sum(e => e.meters)
                                                        });

            foreach (var item in groupMaterialList)
            {
                Console.WriteLine("{0} | {1} | {2} | {3}", item.ID, item.category, item.count, item.meters.ToString("#,##"));
            }
        }
    }

    public class Material
    {
        public string ID { get; set; }
        public string category { get; set; }
        public int count { get; set; }
        public double meters { get; set; }

        public Material()
        {
            // Nothing for now...
        }

        public Material(string id, string category, int count, double meters)
        {
            ID = id;
            this.category = category;
            this.count = count;
            this.meters = meters;
        }
    }
}
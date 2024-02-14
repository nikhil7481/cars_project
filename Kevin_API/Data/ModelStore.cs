using Kevin_API.Models.Dto;

namespace Kevin_API.Data
{
    public static class ModelStore
    {
        public static List<ModelDTO> modelList = new List<ModelDTO> {
            new ModelDTO { Id = 1, Name = "M4", HP=473, Occupancy=4 },
            new ModelDTO { Id = 2, Name = "M5", HP=600, Occupancy=3 },
            };
    }
}



namespace ProniaOnion.Application.DTOs.Products;

public record ProductUpdateDTO(int Id, string Name, decimal Price, string SKU, string? Description, int CategoryId, ICollection<int> ColorIds);

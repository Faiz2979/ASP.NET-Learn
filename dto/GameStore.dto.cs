namespace GameStore.Dto;


public record class GameDto(
    int id,
    string name, 
    string description, 
    decimal price, 
    string publisher, 
    string developer, 
    string genre, 
    string platform, 
    string imageUrl,
    string trailerUrl, 
    DateOnly releaseDate, 
    DateOnly createdDate, 
    DateOnly updatedDate
);

public record class CreateGameDto(
    string name, 
    string description, 
    decimal price, 
    string publisher, 
    string developer, 
    string genre, 
    string platform, 
    string imageUrl,
    string trailerUrl, 
    DateOnly releaseDate
);

public record class PatchGameDto(
    string name, 
    string description, 
    decimal price, 
    string publisher, 
    string developer, 
    string genre, 
    string platform, 
    string imageUrl,
    string trailerUrl, 
    DateOnly releaseDate
);



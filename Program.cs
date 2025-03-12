using System.Diagnostics;
using GameStore.Dto;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
            new GameDto(
            1, 
            "Game One", 
            "Description for Game One", 
            59.99m, 
            "Publisher One", 
            "Developer One", 
            "Action", 
            "PC", 
            "http://example.com/image1.jpg", 
            "http://example.com/trailer1.mp4", 
            new DateOnly(2022, 1, 1), 
            new DateOnly(2021, 12, 1), 
            new DateOnly(2022, 1, 2)
        ),
        new GameDto(
            2, 
            "Game Two", 
            "Description for Game Two", 
            49.99m, 
            "Publisher Two", 
            "Developer Two", 
            "Adventure", 
            "Console", 
            "http://example.com/image2.jpg", 
            "http://example.com/trailer2.mp4", 
            new DateOnly(2022, 2, 1), 
            new DateOnly(2021, 11, 1), 
            new DateOnly(2022, 2, 2)
        ),
        new GameDto(
            3, 
            "Game Three", 
            "Description for Game Three", 
            39.99m, 
            "Publisher Three", 
            "Developer Three", 
            "RPG", 
            "Mobile", 
            "http://example.com/image3.jpg", 
            "http://example.com/trailer3.mp4", 
            new DateOnly(2022, 3, 1), 
            new DateOnly(2021, 10, 1), 
            new DateOnly(2022, 3, 2)
        )
];

// GET /
app.MapGet("/", () => "Hello World! ");

// GET /games
app.MapGet("/games", () => games);
app.MapGet("/games/{id}", (int id) => games.Find(g => g.id == id));

// POST /games
app.MapPost("/games", (CreateGameDto game) => {
    var newGame = new GameDto(
        games.Count + 1, 
        game.name, 
        game.description, 
        game.price, 
        game.publisher, 
        game.developer, 
        game.genre, 
        game.platform, 
        game.imageUrl, 
        game.trailerUrl, 
        game.releaseDate, 
        DateOnly.FromDateTime(DateTime.Now), 
        DateOnly.FromDateTime(DateTime.Now)
    );
    games.Add(newGame);
    return Results.Ok(new { message = "Game added successfully.", game = newGame });
});

// DELETE /games/{id}
app.MapDelete("/games/{id}", (int id) => {
    var game = games.Find(g => g.id == id);
    if (game != null) {
        games.Remove(game);
        return Results.Ok("Game deleted successfully.");
    }
    return Results.NotFound("Game not found.");
});

app.MapPatch("/games/{id}", (int id, PatchGameDto game) => {
    var existingGame = games.Find(g => g.id == id);
    if (existingGame != null) {
        var updatedGame = existingGame with {
            name = game.name,
            description = game.description,
            price = game.price,
            publisher = game.publisher,
            developer = game.developer,
            genre = game.genre,
            platform = game.platform,
            imageUrl = game.imageUrl,
            trailerUrl = game.trailerUrl,
            releaseDate = game.releaseDate,
            updatedDate = DateOnly.FromDateTime(DateTime.Now)
        };
        games[games.IndexOf(existingGame)] = updatedGame;
        return Results.Ok(new { message = "Game updated successfully.", game = updatedGame });
    }
    return Results.NotFound("Game not found.");
});

app.Run();

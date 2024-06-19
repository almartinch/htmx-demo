internal static class Pages {
  const string TITLE = "htmx-demo";
  const string CSS = """https://cdn.jsdelivr.net/npm/@picocss/pico@1/css/pico.min.css""";
  const string HTMX = """https://unpkg.com/htmx.org@2.0.0""";
  enum Levels { averno, sparta };
  
  internal static string Level0 = $"""
  <!doctype html>
  <html lang="en-US">
    <head>
      <meta charset="utf-8" />
      <meta name="viewport" content="width=device-width" />
      <title>{BuildTitle(0)}</title>
      <link rel="stylesheet" href="{CSS}">
    </head>
    
    <body>
    <main class="container">
        <h1>{BuildTitle(0)}</h1>
        <h2>a static asset</h2>
        <img src="images/firefox-icon.png" alt="My test image" />
      </main>
    </body>
  </html>
  """;

  internal static string Level1 = $"""
  <!doctype html>
  <html lang="en">
    <head>
      <meta charset="utf-8" />
      <meta name="viewport" content="width=device-width" />
      <title>{BuildTitle(1)}</title>
      
      <link rel="stylesheet" href="{CSS}">    
      <script src="{HTMX}" integrity="sha384-wS5l5IKJBvK6sPTKa2WZ1js3d947pvWXbPJ1OmWfEuxLgeHcEbjUUA5i9V5ZkpCw" crossorigin="anonymous"></script>
    </head>
    
    <body>
      <main class="container">
        <h1>{BuildTitle(1)}</h1>
        <h2>a button</h2>
        {BuildForm(0)}
      </main>
    </body>
  </html>
  """;
  
  static string BuildTitle(int level) {
    return $"{TITLE} level {level}: {(Levels) level}";
  }

  internal static string BuildForm(int count)
  {
      return $"""
      <form hx-post="/click" hx-swap="outerHTML">
          <label for="count">Count:</label>
          <input type="number" name="count" value="{count}" readonly/>
          <!-- have a button POST a click via AJAX -->
          <button type="submit">Click Me</button>
      </form>
      """;
  }
}

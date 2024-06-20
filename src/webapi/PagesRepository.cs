public static class Constants {
  public const string TITLE = "htmx-demo";
  public const string CSS = """https://cdn.jsdelivr.net/npm/@picocss/pico@1/css/pico.min.css""";
  public const string HTMX = """https://unpkg.com/htmx.org@2.0.0""";
  public const string HTMX_SHA = "sha384-wS5l5IKJBvK6sPTKa2WZ1js3d947pvWXbPJ1OmWfEuxLgeHcEbjUUA5i9V5ZkpCw";
  public enum Levels { averno, sparta };

  public static string BuildTitle(int level) {
    return $"{TITLE} level {level}: {(Levels) level}";
  }
}

public static class PagesRepository {
  public static string Home = $"""
  <html>
    <head>
      <meta charset="UTF-8">
      <title>{Constants.TITLE}</title>
    </head>

    <body>
      Hello <a href="https://www.youtube.com/watch?v=VvSrHIX5a-0">ゴジラ</a> 🦖!      
    </body>
  </html>
  """;
  
  public static string Level0 = $"""
  <!doctype html>
  <html lang="en-US">
    <head>
      <meta charset="utf-8" />
      <meta name="viewport" content="width=device-width" />
      <title>{Constants.BuildTitle(0)}</title>
      <link rel="stylesheet" href="{Constants.CSS}">
    </head>
    
    <body>
    <main class="container">
        <h1>{Constants.BuildTitle(0)}</h1>
        <h2>a static asset</h2>
        <img src="images/firefox-icon.png" alt="My test image" />
      </main>
    </body>
  </html>
  """;

  public static string Level1 = $"""
  <!doctype html>
  <html lang="en">
    <head>
      <meta charset="utf-8" />
      <meta name="viewport" content="width=device-width" />
      <title>{Constants.BuildTitle(1)}</title>
      
      <link rel="stylesheet" href="{Constants.CSS}">    
      <script src="{Constants.HTMX}" integrity="{Constants.HTMX_SHA}" crossorigin="anonymous"></script>
    </head>
    
    <body>
      <main class="container">
        <h1>{Constants.BuildTitle(1)}</h1>
        <h2>a button</h2>
        {BuildForm(0, "/click")}
      </main>
    </body>

    <footer class="container">
      <img src="https://htmx.org/img/createdwith.jpeg" alt"htmx rules"/>
    </footer>
  </html>
  """;
  
  public static string BuildForm(int count, string postEndpoint = "")
  {
      return $"""
      <form hx-post="{postEndpoint}" hx-swap="outerHTML">
          <label for="count">Count:</label>
          <input type="number" name="count" value="{count}" readonly/>
          <!-- have a button POST a click via AJAX -->
          <button type="submit">Click Me</button>
      </form>
      """;
  }
}

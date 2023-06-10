import React, { useContext } from "react";
import { ThemeContext } from "./context/theme.context";

function App() {
  const { darkMode } = useContext(ThemeContext);

  const appStyles = darkMode ? "app dark" : "app";

  return <div>App</div>;
}

export default App;

import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import "./gloabal.scss";
import ThemeContextProvider from "./context/theme.context";

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);
root.render(
  <ThemeContextProvider>
    <App />
  </ThemeContextProvider>
);

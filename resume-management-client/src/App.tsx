import React, { useContext } from "react";
import { ThemeContext } from "./context/theme.context";
import Navbar from "./componetns/navbar/Navbar.component";
import { Routes, Route } from "react-router-dom";
import Home from "./pages/home/home.page";

function App() {
  const { darkMode } = useContext(ThemeContext);

  const appStyles = darkMode ? "app dark" : "app";

  return (
    <div className={appStyles}>
      <Navbar />
      <div className="wrapper">
        <Routes>
          <Route path="/" element={<Home />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;

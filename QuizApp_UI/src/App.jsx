import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Login from "./components/Login";
import QuizGame from "./components/QuizGame/QuizGame";
import "./App.css";

function App() {
  return (
    <>
      <Router>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/quiz" element={<QuizGame />} />
        </Routes>
      </Router>
    </>
  );
}

export default App;
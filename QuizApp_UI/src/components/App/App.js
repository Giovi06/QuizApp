import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import './App.css';
import Dashboard from '../Dashboard/Dashboard';
import Login from '../Login/Login';
import Register from '../Register/Register';
import QuizGame from '../QuizGame/QuizGame';
import useAuth from './useAuth';

function App() {
    const { token, setToken } = useAuth();

    if (!token?.accessToken) {
        return (
            <BrowserRouter>
                <Switch>
                    <Route path="/register">
                        <Register />
                    </Route>
                    <Route path="/">
                        <Login setToken={setToken} />
                    </Route>
                </Switch>
            </BrowserRouter>
        );
    }

    return (
        <div className="app-wrapper">
            <BrowserRouter>
                <Switch>
                    <Route path="/dashboard">
                        <Dashboard />
                    </Route>
                    <Route path="/quiz">
                        <QuizGame />
                    </Route>
                    <Route path="/">
                        <QuizGame />
                    </Route>
                </Switch>
            </BrowserRouter>
        </div>
    );
}

export default App; 
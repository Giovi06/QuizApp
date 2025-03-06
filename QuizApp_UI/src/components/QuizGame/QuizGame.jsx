import React, { useState, useEffect } from 'react';
import './QuizGame.css';

export default function QuizGame() {
    const [question, setQuestion] = useState(null);
    const [selectedAnswer, setSelectedAnswer] = useState(null);
    const [isCorrect, setIsCorrect] = useState(null);
    const [isLoading, setIsLoading] = useState(true);

    const fetchQuestion = async () => {
        setIsLoading(true);
        try {
            const response = await fetch('http://localhost:5270/api/Question/random');
            const data = await response.json();
            setQuestion(data);
            setSelectedAnswer(null);
            setIsCorrect(null);
        } catch (error) {
            console.error('Fehler beim Laden der Frage:', error);
        }
        setIsLoading(false);
    };

    useEffect(() => {
        fetchQuestion();
    }, []);

    useEffect(() => {
        let timer;
        if (isCorrect !== null) {
            timer = setTimeout(() => {
                fetchQuestion();
            }, 5000);
        }
        return () => clearTimeout(timer);
    }, [isCorrect]);

    const handleAnswerClick = (answerNumber) => {
        if (selectedAnswer !== null || isLoading) return;

        setSelectedAnswer(answerNumber);
        setIsCorrect(answerNumber === question.correctAnswer);
    };

    const getButtonClass = (answerNumber) => {
        if (selectedAnswer === null) return '';

        if (answerNumber === question.correctAnswer) {
            return 'correct';
        }

        if (selectedAnswer === answerNumber) {
            return 'incorrect';
        }

        return 'disabled';
    };

    if (isLoading) {
        return (
            <div className="quiz-container">
                <div className="loading">Lade Frage...</div>
            </div>
        );
    }

    return (
        <div className="quiz-container">
            <div className="question">
                <h2>{question?.questionText}</h2>
            </div>
            <div className="answers-grid">
                <button
                    className={`answer-button ${getButtonClass(1)}`}
                    onClick={() => handleAnswerClick(1)}
                    disabled={selectedAnswer !== null}
                >
                    {question?.answer1}
                </button>
                <button
                    className={`answer-button ${getButtonClass(2)}`}
                    onClick={() => handleAnswerClick(2)}
                    disabled={selectedAnswer !== null}
                >
                    {question?.answer2}
                </button>
                <button
                    className={`answer-button ${getButtonClass(3)}`}
                    onClick={() => handleAnswerClick(3)}
                    disabled={selectedAnswer !== null}
                >
                    {question?.answer3}
                </button>
                <button
                    className={`answer-button ${getButtonClass(4)}`}
                    onClick={() => handleAnswerClick(4)}
                    disabled={selectedAnswer !== null}
                >
                    {question?.answer4}
                </button>
            </div>
            {selectedAnswer !== null && (
                <div className={`feedback ${isCorrect ? 'correct' : 'incorrect'}`}>
                    {isCorrect ? 'Richtig!' : 'Falsch!'}
                </div>
            )}
        </div>
    );
} 
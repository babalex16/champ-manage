import React, { useState, useEffect } from 'react';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Dropdown from 'react-bootstrap/Dropdown';
import './Timer.css';

function Timer() {
    //Scoreboard Logic
    const [redScore, setRedScore] = useState(0);
    const [blueScore, setBlueScore] = useState(0);
    const [redAdvantage, setRedAdvantage] = useState(0);
    const [blueAdvantage, setBlueAdvantage] = useState(0);
    const [redPenalty, setRedPenalty] = useState(0);
    const [bluePenalty, setBluePenalty] = useState(0);

    const handleRedButtonClick = (value) => {
        const newScore = redScore + value;
        setRedScore(newScore >= 0 ? newScore : 0);
    };

    const handleBlueButtonClick = (value) => {
        const newScore = blueScore + value;
        setBlueScore(newScore >= 0 ? newScore : 0);
    };

    const handleAdvantageClick = (player) => {
        if (player === 'red') {
            setRedAdvantage((prevAdvantage) => Math.max(prevAdvantage + 1, 0));
        } else if (player === 'blue') {
            setBlueAdvantage((prevAdvantage) => Math.max(prevAdvantage + 1, 0));
        }
    };

    const handlePenaltyClick = (player) => {
        if (player === 'red') {
            if (redPenalty === 0) {
                // First penalty, no changes to advantage or score
                setRedPenalty(1);
            } else if (redPenalty === 1) {
                // Second penalty, give advantage to the blue player
                setRedPenalty(2);
                setBlueAdvantage((prevAdvantage) => Math.max(prevAdvantage + 1, 0));
            } else {
                // Third penalty or more, give 2 points to blue
                setRedPenalty((prevPenalty) => prevPenalty + 1);
                setBlueScore((prevScore) => prevScore + 2);
            }
        } else if (player === 'blue') {
            if (bluePenalty === 0) {
                // First penalty, no changes to advantage or score
                setBluePenalty(1);
            } else if (bluePenalty === 1) {
                // Second penalty, give advantage to the red player
                setBluePenalty(2);
                setRedAdvantage((prevAdvantage) => Math.max(prevAdvantage + 1, 0));
            } else {
                // Third penalty or more, give 2 points to red
                setBluePenalty((prevPenalty) => prevPenalty + 1);
                setRedScore((prevScore) => prevScore + 2);
            }
        }
    };

    const handleRightClickScore = (e, player) => {
        e.preventDefault();
        if (player === 'red') {
            setRedScore((prevScore) => Math.max(prevScore - 1, 0));
        } else if (player === 'blue') {
            setBlueScore((prevScore) => Math.max(prevScore - 1, 0));
        }
    };

    const handleRightClickAdvantage = (e, player) => {
        e.preventDefault();
        if (player === 'red') {
            setRedAdvantage((prevAdvantage) => Math.max(prevAdvantage - 1, 0));
        } else if (player === 'blue') {
            setBlueAdvantage((prevAdvantage) => Math.max(prevAdvantage - 1, 0));
        }
    };

    const handleRightClickPenalty = (e, player) => {
        e.preventDefault();
        if (player === 'red') {
            setRedPenalty((prevPenalty) => Math.max(prevPenalty - 1, 0));
        } else if (player === 'blue') {
            setBluePenalty((prevPenalty) => Math.max(prevPenalty - 1, 0));
        }
    };

    //Timer Logic
    const [time, setTime] = useState(300); // 5 minutes in seconds
    const [timerOn, setTimerOn] = useState(false);

    useEffect(() => {
        let interval;
        if (timerOn) {
            interval = setInterval(() => {
                setTime((prevTime) => (prevTime > 0 ? prevTime - 1 : 0));
            }, 1000);
        }
        return () => clearInterval(interval);
    }, [timerOn]);

    const handleTimerLeftClick = () => {
        setTimerOn(!timerOn);
    };

    const handleTimerRightClick = (e) => {
        e.preventDefault();
        const customTime = prompt('Enter custom time in seconds:');
        if (customTime) {
            setTime(parseInt(customTime));
        }
    };

    const formatTime = (time) => {
        const minutes = Math.floor(time / 60);
        const seconds = time % 60;
        return `${minutes < 10 ? '0' : ''}${minutes}:${seconds < 10 ? '0' : ''}${seconds}`;
    };

    return (
        <Container fluid className='timer-font '>
            <Row className="bg-dark text-white">
                <Col xs={9}>
                    <h2 className="competitor-name">Guțu Șăineanu</h2>
                    <p className="team-name text-secondary">Team Name</p>
                </Col>
                <Col xs={1} className="d-flex flex-column text-center">
                    <p className="text-secondary caption-size m-0">Advantage</p>
                    <p className={`m-0 ${redAdvantage >= 1 ? 'text-success' : 'text-secondary'} advantage-size pointer-cursor`}
                        onClick={() => handleAdvantageClick('red')}
                        onContextMenu={(e) => {
                            handleRightClickAdvantage(e, 'red');
                        }}
                    >
                        {redAdvantage}
                    </p>

                    <p className="text-secondary caption-size m-0">Penalty</p>
                    <p className={`m-0 ${redPenalty >= 1 ? 'text-danger' : 'text-secondary'} advantage-size pointer-cursor`}
                        onClick={() => handlePenaltyClick('red')}
                        onContextMenu={(e) => {
                            handleRightClickPenalty(e, 'red');
                        }}
                    >
                        {redPenalty}
                    </p>
                </Col>
                <Col xs={2} className="bg-danger d-flex align-items-center justify-content-center"
                    onContextMenu={(e) => {
                        handleRightClickScore(e, 'red');
                    }}>
                    <Dropdown>
                        <Dropdown.Toggle variant="danger" className='points-size no-caret' id="redScore">
                            {redScore}
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            <Dropdown.Item onClick={() => handleRedButtonClick(4)} className='text-center'>+4</Dropdown.Item>
                            <Dropdown.Item onClick={() => handleRedButtonClick(3)} className='text-center'>+3</Dropdown.Item>
                            <Dropdown.Item onClick={() => handleRedButtonClick(2)} className='text-center'>+2</Dropdown.Item>
                        </Dropdown.Menu>
                    </Dropdown>
                </Col>
            </Row>
            <Row className="bg-dark text-white">
                <Col xs={9}>
                    <h2 className="competitor-name">Gheorghe Dumitrescu</h2>
                    <p className="team-name text-secondary">Team Name</p>
                </Col>
                <Col xs={1} className="d-flex flex-column text-center">
                    <p className="text-secondary caption-size m-0">Advantage</p>
                    <p className={`m-0 ${blueAdvantage >= 1 ? 'text-success' : 'text-secondary'} advantage-size pointer-cursor`}
                        onClick={() => handleAdvantageClick('blue')}
                        onContextMenu={(e) => {
                            handleRightClickAdvantage(e, 'blue');
                        }}
                    >
                        {blueAdvantage}
                    </p>
                    <p className="text-secondary caption-size m-0">Penalty</p>
                    <p className={`m-0 ${bluePenalty >= 1 ? 'text-danger' : 'text-secondary'} advantage-size pointer-cursor`}
                        onClick={() => handlePenaltyClick('blue')}
                        onContextMenu={(e) => {
                            handleRightClickPenalty(e, 'blue');
                        }}
                    >
                        {bluePenalty}
                    </p>
                </Col>
                <Col xs={2} className="bg-primary d-flex align-items-center justify-content-center"
                    onContextMenu={(e) => {
                        handleRightClickScore(e, 'blue');
                    }}>
                    <Dropdown>
                        <Dropdown.Toggle variant="primary" className='points-size no-caret' id="blueScore">
                            {blueScore}
                        </Dropdown.Toggle>
                        <Dropdown.Menu>
                            <Dropdown.Item onClick={() => handleBlueButtonClick(4)} className='text-center'>+4</Dropdown.Item>
                            <Dropdown.Item onClick={() => handleBlueButtonClick(3)} className='text-center'>+3</Dropdown.Item>
                            <Dropdown.Item onClick={() => handleBlueButtonClick(2)} className='text-center'>+2</Dropdown.Item>
                        </Dropdown.Menu>
                    </Dropdown>
                </Col>
            </Row>
            <Row className="bg-dark text-white">
                <Col className="d-flex align-items-center">
                    <h2 className="category-size">Adults/ Male/ -85kg</h2>
                </Col>
                <Col >
                    <h1
                        className={`timer-size text-end ${!timerOn ? 'hover-animation' : ''}`}
                        onClick={handleTimerLeftClick}
                        onContextMenu={handleTimerRightClick}
                    >
                        {formatTime(time)}
                    </h1>

                </Col>
            </Row>
        </Container>
    );
}

export default Timer;

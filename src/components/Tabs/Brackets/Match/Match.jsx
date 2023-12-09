
import Participant from './Participant/Participant';

import './match.css';

const Match = () => {
    return (
        <div className="column one">
            <div className="match winner-top">
                <div className="match-top team">
                    <span className="image"></span>
                    <span className="seed">1</span>
                    <Participant name={"Orlando Jetsetters"}/>
                    <span className="score">2</span>
                </div>
                <div className="match-bottom team">
                    <span className="image"></span>
                    <span className="seed">1</span>
                    <Participant name={"Orlando Jetsetters"}/>
                    <span className="score">2</span>
                </div>
                <div className="match-lines">
                    <div className="line one"></div>
                    <div className="line two"></div>
                </div>
                <div className="match-lines alt">
                    <div className="line one"></div>
                </div>
            </div>
        </div>
    )
}

export default Match;
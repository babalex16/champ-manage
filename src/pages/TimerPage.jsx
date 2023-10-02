import React from 'react';
import { FullScreen, useFullScreenHandle } from "react-full-screen";
import Timer from '../components/Timer/Timer';

function TimerPage() {
    const handle = useFullScreenHandle();
    return (
        <div style={{ paddingTop: '80px', backgroundColor: '#183D3D', minHeight: '100vh' }}>
            <button onClick={handle.enter}>
                Enter fullscreen
            </button>
            <FullScreen handle={handle}>
                <Timer />
            </FullScreen>
        </div>
    )
}

export default TimerPage
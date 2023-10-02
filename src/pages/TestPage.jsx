import OverlayTrigger from 'react-bootstrap/OverlayTrigger';
import Popover from 'react-bootstrap/Popover';
import { FullScreen, useFullScreenHandle } from 'react-full-screen';

function TestPage() {
  const handle = useFullScreenHandle();
  const popover = (
    <Popover id="popover-basic">
      <Popover.Header as="h3">Popover bottom</Popover.Header>
      <Popover.Body>
        And here's some <strong>amazing</strong> content. It's very engaging. right?
      </Popover.Body>
    </Popover>
  );

  return (
    <div style={{ paddingTop: '75px', backgroundColor: '#5c8374', minHeight: '100vh' }}>
      <button onClick={handle.enter}>Enter fullscreen</button>
      <FullScreen handle={handle}>
        {/* Set the container to FullScreen */}
        <OverlayTrigger trigger="click" placement="bottom" overlay={popover} container={handle.fullScreen}>
          <div style={{ width: '100px', height: '100px', backgroundColor: 'red' }} />
        </OverlayTrigger>
      </FullScreen>
    </div>
  );
}

export default TestPage;

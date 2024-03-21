import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import './App.css';
import ChoreGrid from './ChoreGrid'
import Calendar from './Calendar'

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <ChoreGrid />
      </header>
      <Calendar />
    </div>
  );
}

export default App;


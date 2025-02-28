import logo from './logo.svg';
import './App.css';
import First from './components/first/first';
import Second from './components/second/second';
import Third from './components/third/third';
import ButtonEx from './components/buttonex/buttonex';
import Four from './components/four/four';
import Five from './components/five/five';

function App() {
  return (
    <div className="App">
      <br/>
      <First></First>
      <br/>
      <Second/>
      <br/>
      <Third firstName="Sai" lastName="Shravani" company="Wipro" /> <br/>
      <br/>
      <ButtonEx/>
      <br/>
      <Four/>
      <br/>
      <Five/>


    </div>
  );
}

export default App;

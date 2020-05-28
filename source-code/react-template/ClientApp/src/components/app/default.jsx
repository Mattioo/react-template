import React, {Component} from 'react';
import styles from '../../styles/app/default.scss';

const content = 'Hello world!';

class App extends Component {

  componentWillMount() {
    // fetch info about styles to import
  }

  render() {
    return (
        <p className={styles.p}>{content}</p>
    );
  }
}

export default App;
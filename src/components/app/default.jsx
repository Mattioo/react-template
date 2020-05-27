import React, {Component} from 'react';
import styles from '../../styles/app/default.scss';

const content = 'Hello world!';

class App extends Component {
  render() {
    return (
        <p className={styles.p}>{content}</p>
    );
  }
}

export default App;
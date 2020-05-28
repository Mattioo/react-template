import styles from '../../styles/app/styles.scss';
import React, { Component } from 'react';

import { library, dom } from "@fortawesome/fontawesome-svg-core";
import { faCheck } from "@fortawesome/free-solid-svg-icons/faCheck";

library.add(faCheck);
dom.watch();

const content = 'Hello world!';

class App extends Component {
  render() {
      return (
          <div>
              <p className={styles.test1}>{content}</p>
              <p className={styles.test1}>
                  <span className={styles.test2}>Lorem ipsum..</span>
              </p>
              <p className={styles.test1_test3}>Lorem ipsum..</p>
              <i className={styles.icon + " fas fa-check"}></i>
          </div>
    );
  }
}

export default App;
import ReactFlagsSelect from 'react-flags-select';
import styles from './header-styles.module.scss';

const HeaderTemplate = (props) => {
    return (
        <div className={`${styles.header}${(props.contrast ? ' ' + styles.contrast : '')}`}>
            <div className={styles.headerButtons}>
                <div onClick={() => props.changeFontSize(props.fontSize - 10)}>
                    <strong>A-</strong>
                </div>

                <div onClick={() => props.changeFontSize(props.fontSize + 10)}>
                    <strong>A+</strong>
                </div>

                <div onClick={() => props.toogleContrast(!props.contrast)}>
                    <span>Wersja kontrastowa</span>
                </div>
            </div>
            <div className={styles.headerLanguage}>
                <ReactFlagsSelect
                    selected={props.language.set}
                    onSelect={code => props.changeLanguage(code)}
                    countries={props.language.availables}
                    showSelectedLabel={false}
                    fullWidth={false}
                    alignOptionsToRight={true}
                    className={styles.headerLanguageList}
                />
            </div>
        </div>
    );
}

export default HeaderTemplate;

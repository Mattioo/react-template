import ReactFlagsSelect from 'react-flags-select';
import './header.scss';

const Header = (props) => {

    const style = { fontSize: `${props.fontSize}%` };

    return (
        <header className={props.contrast ? "contrast" : null}>
            <div className='header-buttons'>
                <div onClick={() => props.changeFontSize(props.fontSize - 10)}>
                    <strong style={style}>A-</strong>
                </div>

                <div onClick={() => props.changeFontSize(props.fontSize + 10)}>
                    <strong style={style}>A+</strong>
                </div>

                <div onClick={() => props.toogleContrast(!props.contrast)}>
                    <span style={style}>Wersja kontrastowa</span>
                </div>
            </div>
            <div className='header-language'>
                <ReactFlagsSelect
                    selected={props.language.set}
                    onSelect={code => props.changeLanguage(code)}
                    countries={props.language.availables}
                    showSelectedLabel={false}
                    fullWidth={false}
                    alignOptionsToRight={true}
                    className='header-language-list'
                />
            </div>
        </header>
    );
}

export default Header;

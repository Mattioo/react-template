import ReactFlagsSelect from 'react-flags-select';
import './header.scss';

const Header = (props) => {
    return (
        <div className={props.contrast ? "header contrast" : "header"}>
            <div className='header-buttons'>
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
        </div>
    );
}

export default Header;

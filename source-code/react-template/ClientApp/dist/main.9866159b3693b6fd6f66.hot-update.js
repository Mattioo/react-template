webpackHotUpdate("main",{

/***/ "./node_modules/country-flag-icons/modules/react/3x2/index.js":
false,

/***/ "./node_modules/country-flag-icons/modules/unicode.js":
/*!************************************************************!*\
  !*** ./node_modules/country-flag-icons/modules/unicode.js ***!
  \************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "default", function() { return getCountryFlag; });
/**
 * Creates Unicode flag from a two-letter ISO country code.
 * https://stackoverflow.com/questions/24050671/how-to-put-japan-flag-character-in-a-string
 * @param  {string} country — A two-letter ISO country code (case-insensitive).
 * @return {string}
 */
function getCountryFlag(country) {
  return getRegionalIndicatorSymbol(country[0]) + getRegionalIndicatorSymbol(country[1]);
}
/**
 * Converts a letter to a Regional Indicator Symbol.
 * @param  {string} letter
 * @return {string}
 */

function getRegionalIndicatorSymbol(letter) {
  return String.fromCodePoint(0x1F1E6 - 65 + letter.toUpperCase().charCodeAt(0));
}
//# sourceMappingURL=unicode.js.map

/***/ }),

/***/ "./node_modules/country-flag-icons/react/3x2/index.js":
false,

/***/ "./node_modules/country-flag-icons/unicode/index.js":
/*!**********************************************************!*\
  !*** ./node_modules/country-flag-icons/unicode/index.js ***!
  \**********************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _modules_unicode__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../modules/unicode */ "./node_modules/country-flag-icons/modules/unicode.js");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "default", function() { return _modules_unicode__WEBPACK_IMPORTED_MODULE_0__["default"]; });



/***/ }),

/***/ "./src/components/toolbar/index.jsx":
/*!******************************************!*\
  !*** ./src/components/toolbar/index.jsx ***!
  \******************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! react */ "./node_modules/react/index.js");
/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var country_flag_icons_unicode__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! country-flag-icons/unicode */ "./node_modules/country-flag-icons/unicode/index.js");
/* harmony import */ var country_flag_icons__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! country-flag-icons */ "./node_modules/country-flag-icons/index.js");




var Toolbar = function Toolbar(_ref) {
  var fontSize = _ref.fontSize,
      setFontSize = _ref.setFontSize,
      contrast = _ref.contrast,
      setContrast = _ref.setContrast,
      languages = _ref.languages,
      lang = _ref.lang,
      setLang = _ref.setLang;
  return /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react__WEBPACK_IMPORTED_MODULE_0___default.a.Fragment, null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar".concat(contrast ? ' app-toolbar--contrast' : '')
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--left"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      return setFontSize(Math.max(fontSize - 10, 50));
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "A-")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      return setFontSize(100);
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "A")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      return setFontSize(Math.min(fontSize + 10, 150));
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "A+")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      return setContrast(!contrast);
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "Wersja kontrastowa"))), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--right"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item"
  }, Object(country_flag_icons_unicode__WEBPACK_IMPORTED_MODULE_1__["default"])('US'), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, lang)))));
};

/* harmony default export */ __webpack_exports__["default"] = (Toolbar);

/***/ })

})
//# sourceMappingURL=main.9866159b3693b6fd6f66.hot-update.js.map
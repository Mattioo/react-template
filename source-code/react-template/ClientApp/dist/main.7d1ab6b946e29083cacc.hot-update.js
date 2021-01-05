webpackHotUpdate("main",{

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


var Toolbar = function Toolbar(_ref) {
  var fontSize = _ref.fontSize,
      setFontSize = _ref.setFontSize,
      contrast = _ref.contrast,
      setContrast = _ref.setContrast,
      languages = _ref.languages,
      lang = _ref.lang,
      setLang = _ref.setLang;
  return /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement(react__WEBPACK_IMPORTED_MODULE_0___default.a.Fragment, null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar".concat(contrast ? ' contrast' : '')
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--left"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      var size = Math.min(fontSize + 10, 130);

      if (window.sessionStorage) {
        window.sessionStorage.setItem('fontSize', size);
      }

      setFontSize(size);
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "A+")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      var size = Math.max(fontSize - 10, 100);

      if (window.sessionStorage) {
        window.sessionStorage.setItem('fontSize', size);
      }

      setFontSize(size);
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "A-")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      if (window.sessionStorage) {
        window.sessionStorage.setItem('contrast', !contrast);
      }

      setContrast(!contrast);
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("span", null, "Wersja kontrastowa"))), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--right"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--item--lang"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--lang"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("i", {
    className: "flag:".concat(lang)
  })), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("div", {
    className: "app-toolbar--lang--list"
  }, languages.filter(function (x) {
    return x["short"] !== lang;
  }).map(function (language) {
    return /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_0___default.a.createElement("i", {
      key: language["short"],
      className: "app-toolbar--language flag:".concat(language["short"]),
      title: language.name,
      onClick: function onClick() {
        return setLang(language["short"]);
      }
    });
  }))))));
};

/* harmony default export */ __webpack_exports__["default"] = (Toolbar);

/***/ })

})
//# sourceMappingURL=main.7d1ab6b946e29083cacc.hot-update.js.map
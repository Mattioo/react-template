webpackHotUpdate("main",{

/***/ "./src/components/toolbar/index.jsx":
/*!******************************************!*\
  !*** ./src/components/toolbar/index.jsx ***!
  \******************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @babel/runtime/helpers/slicedToArray */ "./node_modules/@babel/runtime/helpers/slicedToArray.js");
/* harmony import */ var _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! react */ "./node_modules/react/index.js");
/* harmony import */ var react__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(react__WEBPACK_IMPORTED_MODULE_1__);



var Toolbar = function Toolbar(_ref) {
  var fontSize = _ref.fontSize,
      setFontSize = _ref.setFontSize,
      contrast = _ref.contrast,
      setContrast = _ref.setContrast,
      languages = _ref.languages,
      lang = _ref.lang,
      setLang = _ref.setLang;

  var _useState = Object(react__WEBPACK_IMPORTED_MODULE_1__["useState"])(false),
      _useState2 = _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default()(_useState, 2),
      languageListVisible = _useState2[0],
      setLanguageListVisible = _useState2[1];

  return /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement(react__WEBPACK_IMPORTED_MODULE_1___default.a.Fragment, null, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("div", {
    className: "app-toolbar".concat(contrast ? ' contrast' : '')
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("div", {
    className: "app-toolbar--left"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      var size = Math.min(fontSize + 10, 130);

      if (window.sessionStorage) {
        window.sessionStorage.setItem('fontSize', size);
      }

      setFontSize(size);
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("span", null, "A+")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      var size = Math.max(fontSize - 10, 100);

      if (window.sessionStorage) {
        window.sessionStorage.setItem('fontSize', size);
      }

      setFontSize(size);
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("span", null, "A-")), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("div", {
    className: "app-toolbar--item",
    onClick: function onClick() {
      if (window.sessionStorage) {
        window.sessionStorage.setItem('contrast', !contrast);
      }

      setContrast(!contrast);
    }
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("span", null, "Wersja kontrastowa"))), /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("div", {
    className: "app-toolbar--right"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("div", {
    className: "app-toolbar--lang--item"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("div", {
    className: "app-toolbar--lang"
  }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("i", {
    className: "flag:".concat(lang)
  }))), languageListVisible ? /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("div", {
    className: "app-toolbar--lang--list",
    onMouseLeave: function onMouseLeave() {
      alert();
    }
  }, languages.filter(function (x) {
    return x["short"] !== lang;
  }).map(function (language) {
    return /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("div", {
      className: "app-toolbar--lang",
      key: language["short"],
      title: language.name
    }, /*#__PURE__*/react__WEBPACK_IMPORTED_MODULE_1___default.a.createElement("i", {
      className: "flag:".concat(language["short"]),
      onClick: function onClick() {
        if (window.sessionStorage) {
          window.sessionStorage.setItem('lang', language["short"]);
        }

        setLang(language["short"]);
      }
    }));
  })) : null)));
};

/* harmony default export */ __webpack_exports__["default"] = (Toolbar);

/***/ })

})
//# sourceMappingURL=main.1491101e45f311c81333.hot-update.js.map
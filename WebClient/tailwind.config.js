/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["**/*.cshtml"],
    theme: {
        extend: {},
    },
    plugins: [require("daisyui")],
    daisyui: {
        darkTheme: "ayu-dark",
        themes: [
            {
                "ayu-light": {
                    "primary": "#55B4D4",
                    "secondary": "#6CBF43",
                    "accent": "#FFAA33",
                    "neutral": "#ACB6BF",
                    "base-100": "#FCFCFC",
                    "base-200": "#F3F4F5",
                    "base-300": "#ACB6BF",
                    "info": "#399EE6",
                    "success": "#6CBF43",
                    "warning": "#F2AE49",
                    "error": "#E65050",
                },
                "ayu-mirage": {
                    "primary": "#5CCFE6",
                    "secondary": "#87D96C",
                    "accent": "#FFCC66",
                    "neutral": "#B8CFE6",
                    "base-100": "#242936",
                    "base-200": "#1F2430",
                    "base-300": "#1C212B",
                    "info": "#73D0FF",
                    "success": "#87D96C",
                    "warning": "#FFD173",
                    "error": "#FF6666",
                },
                "ayu-dark": {
                    "primary": "#39BAE6",
                    "secondary": "#7FD962",
                    "accent": "#E6B450",
                    "neutral": "#ACB6BF",
                    "base-100": "#0F131A",
                    "base-200": "#0D1017",
                    "base-300": "#0B0E14",
                    "info": "#59C2FF",
                    "success": "#7FD962",
                    "warning": "#FFB454",
                    "error": "#D95757",
                },
                "catpuccin-latte": {
                    "primary": "#04a5e5",
                    "secondary": "#40a02b",
                    "accent": "#ea76cb",
                    "neutral": "#9ca0b0",
                    "base-100": "#eff1f5",
                    "base-200": "#e6e9ef",
                    "base-300": "#dce0e8",
                    "info": "#04a5e5",
                    "success": "#40a02b",
                    "warning": "#df8e1d",
                    "error": "#e64553",

                },
                "catpuccin-frappe": {
                    "primary": "#99d1db",
                    "secondary": "#a6d189",
                    "accent": "#f4b8e4",
                    "neutral": "#737994",
                    "base-100": "#303446",
                    "base-200": "#292c3c",
                    "base-300": "#232634",
                    "info": "#99d1db",
                    "success": "#a6d189",
                    "warning": "#e5c890",
                    "error": "#ea999c",

                },
                "catpuccin-macchiato": {
                    "primary": "#91d7e3",
                    "secondary": "#a6da95",
                    "accent": "#f5bde6",
                    "neutral": "#6e738d",
                    "base-100": "#24273a",
                    "base-200": "#1e2030",
                    "base-300": "#181926",
                    "info": "#91d7e3",
                    "success": "#a6da95",
                    "warning": "#eed49f",
                    "error": "#ee99a0",

                },
                "catpuccin-mocha": {
                    "primary": "#89dceb",
                    "secondary": "#a6e3a1",
                    "accent": "#f5c2e7",
                    "neutral": "#6c7086",
                    "base-100": "#1e1e2e",
                    "base-200": "#181825",
                    "base-300": "#11111b",
                    "info": "#89dceb",
                    "success": "#a6e3a1",
                    "warning": "#f9e2af",
                    "error": "#eba0ac",
                },
            },
        ],
    },
}


# PrintityFramework
A farmework to provide printing and formatting cabapilities to your code within few easy steps

# Design
This framework is intended to provide an easy-to-design printing documents with rich designing APIs

# Dependency
This framework depends on
- System.Drawing.Common assembly
- PdfSharpCore assembly (this is an older one but we've used it for license)
# Nuget package url
- https://www.nuget.org/packages/TalkingCSharp.PrintityFramework
# Printity framework API reference manual and web demo
- https://printity.azurewebsites.net/ (this is a free hosted service on azure so it'll be slow responding and might be not available sometimes as a free service)
# API demo
- Call HTTPPOST to this API: https://printity.azurewebsites.net/api/Demo
- Abd here is a JSON example for the demo
...json
{
    "paperSize": "A4",
    "tables": [
      {
        "columns": [
          {
            "propertyName": "Index",
            "headerText": "#",
            "width": 25,
            "widthUnit": "Percent",
            "headerFont": {
              "fontName": "Arial",
              "bold": true,
              "italic": false,
              "underline": false,
              "size": 12,
              "color": {
                "colorName": "Black"
              }
            },
            "font": {
              "fontName": "Arial",
              "bold": false,
              "italic": false,
              "underline": false,
              "size": 10,
              "color": {
                "colorName": "Black"
              }
            },
            "alternatingFont": {
              "fontName": "Arial",
              "bold": false,
              "italic": false,
              "underline": false,
              "size": 10,
              "color": {
                "colorName": "Black"
              }
            },
            "headerHAlign": "Center",
            "headerVAlien": "Top",
            "hAlign": "Center",
            "vAlien": "Top",
            "backgroundColor": {
              "colorName": "White"
            },
            "headerBackgroundColor": {
              "colorName": "White"
            },
            "alternateBackgroundColor": {
                "colorName": null,
              "colorHex": "#BBB"
            },
            "border": {
              "borderColor": {
                "colorName": "Black"
              },
              "topBorderColor": {
                "colorName": "Black"
              },
              "leftBorderColor": {
                "colorName": "Black"
              },
              "bottomBorderColor": {
                "colorName": "Black"
              },
              "rightBorderColor": {
                "colorName": "Black"
              },
              "borderSize": 1,
              "topBorderSize": 1,
              "leftBorderSize": 1,
              "bottomBorderSize": 1,
              "rightBorderSize": 1
            },
            "headerBorder": {
                "borderColor": {
                  "colorName": "Black"
                },
                "topBorderColor": {
                  "colorName": "Black"
                },
                "leftBorderColor": {
                  "colorName": "Black"
                },
                "bottomBorderColor": {
                  "colorName": "Black"
                },
                "rightBorderColor": {
                  "colorName": "Black"
                },
                "borderSize": 1,
                "topBorderSize": 1,
                "leftBorderSize": 1,
                "bottomBorderSize": 1,
                "rightBorderSize": 1
              }
          },
          {
            "propertyName": "Bool",
            "headerText": "Boolean value",
            "width": 25,
            "widthUnit": "Percent",
            "headerFont": {
              "fontName": "Arial",
              "bold": true,
              "italic": false,
              "underline": false,
              "size": 12,
              "color": {
                "colorName": "Black"
              }
            },
            "font": {
              "fontName": "Arial",
              "bold": false,
              "italic": false,
              "underline": false,
              "size": 10,
              "color": {
                "colorName": "Black"
              }
            },
            "alternatingFont": {
              "fontName": "Arial",
              "bold": false,
              "italic": false,
              "underline": false,
              "size": 10,
              "color": {
                "colorName": "Black"
              }
            },
            "headerHAlign": "Center",
            "headerVAlien": "Top",
            "hAlign": "Center",
            "vAlien": "Top",
            "backgroundColor": {
              "colorName": "White"
            },
            "headerBackgroundColor": {
              "colorName": "White"
            },
            "alternateBackgroundColor": {
                "colorName": null,
                "colorHex": "#BBB"            },
            "border": {
              "borderColor": {
                "colorName": "Black"
              },
              "topBorderColor": {
                "colorName": "Black"
              },
              "leftBorderColor": {
                "colorName": "Black"
              },
              "bottomBorderColor": {
                "colorName": "Black"
              },
              "rightBorderColor": {
                "colorName": "Black"
              },
              "borderSize": 1,
              "topBorderSize": 1,
              "leftBorderSize": 1,
              "bottomBorderSize": 1,
              "rightBorderSize": 1
            },
            "headerBorder": {
                "borderColor": {
                  "colorName": "Black"
                },
                "topBorderColor": {
                  "colorName": "Black"
                },
                "leftBorderColor": {
                  "colorName": "Black"
                },
                "bottomBorderColor": {
                  "colorName": "Black"
                },
                "rightBorderColor": {
                  "colorName": "Black"
                },
                "borderSize": 1,
                "topBorderSize": 1,
                "leftBorderSize": 1,
                "bottomBorderSize": 1,
                "rightBorderSize": 1
              }
          },
          {
            "propertyName": "String",
            "headerText": "String value",
            "width": 50,
            "widthUnit": "Percent",
            "headerFont": {
              "fontName": "Arial",
              "bold": true,
              "italic": false,
              "underline": false,
              "size": 12,
              "color": {
                "colorName": "Black"
              }
            },
            "font": {
              "fontName": "Arial",
              "bold": false,
              "italic": false,
              "underline": false,
              "size": 10,
              "color": {
                "colorName": "Black"
              }
            },
            "alternatingFont": {
              "fontName": "Arial",
              "bold": false,
              "italic": false,
              "underline": false,
              "size": 10,
              "color": {
                "colorName": "Black"
              }
            },
            "headerHAlign": "Center",
            "headerVAlien": "Top",
            "hAlign": "Center",
            "vAlien": "Top",
            "backgroundColor": {
              "colorName": "White"
            },
            "headerBackgroundColor": {
              "colorName": "White"
            },
            "alternateBackgroundColor": {
                "colorName": null,
                "colorHex": "#BBB"            },
            "border": {
              "borderColor": {
                "colorName": "Black"
              },
              "topBorderColor": {
                "colorName": "Black"
              },
              "leftBorderColor": {
                "colorName": "Black"
              },
              "bottomBorderColor": {
                "colorName": "Black"
              },
              "rightBorderColor": {
                "colorName": "Black"
              },
              "borderSize": 1,
              "topBorderSize": 1,
              "leftBorderSize": 1,
              "bottomBorderSize": 1,
              "rightBorderSize": 1
            },
            "headerBorder": {
                "borderColor": {
                  "colorName": "Black"
                },
                "topBorderColor": {
                  "colorName": "Black"
                },
                "leftBorderColor": {
                  "colorName": "Black"
                },
                "bottomBorderColor": {
                  "colorName": "Black"
                },
                "rightBorderColor": {
                  "colorName": "Black"
                },
                "borderSize": 1,
                "topBorderSize": 1,
                "leftBorderSize": 1,
                "bottomBorderSize": 1,
                "rightBorderSize": 1
              }
          }
        ],
        "rowHeaderHeight": 10,
        "rowHeight": 8,
        "bounds": {
          "x": 2,
          "y": 10,
          "width": 96,
          "height": 30
        },
        "boundsUnit": "Percent",
        "backgroundColor": {
          "colorName": "White"
        },
        "headerBackgroundColor": {
          "colorName": "White"
        },
        "alternateBackgroundColor": {
            "colorName": null,
            "colorHex": "#BBB"        },
        "data": [
            {
              "Index":1,
              "Bool": true,
              "String": "First string"
            },
            {
                "Index":2,
                "Bool": false,
                "String": "Second string"
              },
              {
                "Index":3,
                "String": "Third string"
              },
              {
                "Index":4,
                "Bool": true,
                "String": "Forth string"
              },
              {
                "Index":5,
                "Bool": false,
                "String": "Fifth string"
              },
              {
                "Index":6,
                "String": "Sixth string"
              }
            ]
      }
    ],
    "labels": [
      {
        "backgroundColor": {
          "colorName": null,
          "colorHex": "#CCC"
        },
        "bounds": {
          "x": 20,
          "y": 5,
          "width": 60,
          "height": 3
        },
        "boundsUnit": "Percent",
        "text": "Printity framework test document",
        "font": {
          "fontName": "Arial",
          "bold": true,
          "italic": false,
          "underline": false,
          "size": 12,
          "color": {
            "colorName": "Black"
          }
        },
        "hAlign": "Center",
        "border": {
          "borderColor": {
            "colorName": "White",
            "colorHex": "#FFF",
            "colorR": 255,
            "colorG": 255,
            "colorB": 255
          },
          "topBorderColor": {
            "colorName": "White",
            "colorHex": "#FFF",
            "colorR": 255,
            "colorG": 255,
            "colorB": 255
          },
          "leftBorderColor": {
            "colorName": "White",
            "colorHex": "#FFF",
            "colorR": 255,
            "colorG": 255,
            "colorB": 255
          },
          "bottomBorderColor": {
            "colorName": "Black"
          },
          "rightBorderColor": {
            "colorName": "White",
            "colorHex": "#FFF",
            "colorR": 255,
            "colorG": 255,
            "colorB": 255
          },
          "borderSize": 0,
          "topBorderSize": 0,
          "leftBorderSize": 0,
          "bottomBorderSize": 1,
          "rightBorderSize": 0
        }
      },
      {
        "backgroundColor": {
          "colorName": "White",
          "colorHex": "#FFF",
          "colorR": 255,
          "colorG": 255,
          "colorB": 255
        },
        "bounds": {
          "x": 5,
          "y": 95,
          "width": 90,
          "height": 2.5
        },
        "boundsUnit": "Percent",
        "text": "This test document was created using printity framework",
        "font": {
          "fontName": "Arial",
          "bold": false,
          "italic": false,
          "underline": false,
          "size": 10,
          "color": {
            "colorName": "DarkRed"}
        },
        "hAlign": "Left",
        "border": {
          "borderColor": {
            "colorName": "Red"
        },
          "topBorderColor": {
            "colorName": "Red"
          },
          "leftBorderColor": {
            "colorName": "Red"
          },
          "bottomBorderColor": {
            "colorName": "Red"
          },
          "rightBorderColor": {
            "colorName": "Red"
          },
          "borderSize": 1,
          "topBorderSize": 1,
          "leftBorderSize": 1,
          "bottomBorderSize": 1,
          "rightBorderSize": 1
        }
      }
    ],
    "placeHeaderValues": [
      {
        "bounds": {
          "x": 40,
          "y": 88,
          "width": 20,
          "height": 2.5
        },
        "boundsUnit": "Percent",
        "headerBounds": {
          "x": 20,
          "y": 88,
          "width": 20,
          "height": 2.5
        },
        "headerBoundsUnit": "Percent",
        "header": "Total records",
        "text": "6 records",
        "font": {
          "fontName": "Arial",
          "bold": false,
          "italic": false,
          "underline": false,
          "size": 8,
          "color": {
            "colorName": "Black"
          }
        },
        "headerFont": {
          "fontName": "Arial",
          "bold": true,
          "italic": false,
          "underline": false,
          "size": 10,
          "color": {
            "colorName": "Navy"
          }
        },
        "headerHAlign": "Left",
        "headerVAlien": "Top",
        "hAlign": "Left",
        "vAlien": "Top",
        "backGroundColor": {
          "colorName": "White"
        },
        "headerBackgroundColor": {
          "colorName": null,
          "colorHex": "#ABC"
        },
        "border": {
          "borderColor": {
            "colorName": "Black"
          },
          "topBorderColor": {
            "colorName": "Black"
          },
          "leftBorderColor": {
            "colorName": "Black"
          },
          "bottomBorderColor": {
            "colorName": "Black"
          },
          "rightBorderColor": {
            "colorName": "Black"
          },
          "borderSize": 1,
          "topBorderSize": 1,
          "leftBorderSize": 1,
          "bottomBorderSize": 1,
          "rightBorderSize": 1
        },
        "headerBorder": {
          "borderColor": {
            "colorName": "Purple"
          },
          "topBorderColor": {
            "colorName": "Purple"
          },
          "leftBorderColor": {
            "colorName": "Purple"
          },
          "bottomBorderColor": {
            "colorName": "Purple"
          },
          "rightBorderColor": {
            "colorName": "Purple"
          },
          "borderSize": 1,
          "topBorderSize": 1,
          "leftBorderSize": 1,
          "bottomBorderSize": 1,
          "rightBorderSize": 1
        }
      }
    ]
  }
...
# project URL
Project URL is where to find the already implemented features and the in-progress ones and the future of this library
- This library's project URL is here: https://github.com/users/Talkingcsharp/projects/4
# Final notes
This is an open source project and is unlimitly free to use on your own projects, just please give us a star.
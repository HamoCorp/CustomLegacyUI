using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using ResoniteModLoader;
using FrooxEngine;
using Elements.Core;
using FrooxEngine.UIX;

namespace CustomLegacyUI{

    public class Class1 : ResoniteMod {
        public override string Name => "CustomLegacyUI";
        public override string Author => "HamoCorp";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/HamoCorp/CustomLegacyUI/";

        private static ModConfiguration Config;

        private static float3 _DefultButtonSize = new float3(0.25f, 0.05f, 0.005f);

        private static float _DefultCheckboxsize = (float)0.1;
        private static float _DefultCheckboxBevel = (float)0.25;

        private static float _DefultSliderSlant = 22.5f;

        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> _enabled = new ModConfigurationKey<bool>("enabled", "Enabled - disabling this mod, sets all legacy UI to the boring defult", () => true);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d100 = new ModConfigurationKey<dummy>("                                                                                      ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d101 = new ModConfigurationKey<dummy>("                                                                                       ", "\r█▀▀ █░█ █▀ ▀█▀ █▀█ █▀▄▀█   █░░ █▀▀ █▀▀ ▄▀█ █▀▀ █▄█   █░█ █");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d102 = new ModConfigurationKey<dummy>("                                                                                        ", "\r█▄▄ █▄█ ▄█ ░█░ █▄█ █░▀░█   █▄▄ ██▄ █▄█ █▀█ █▄▄ ░█░   █▄█ █");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d0 = new ModConfigurationKey<dummy>(" ", "------------------------------------------------------------------------------------------------------------------------------------------");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d1 = new ModConfigurationKey<dummy>("  ", "");

        // button

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<bool> _customButtons = new ModConfigurationKey<bool>("Buttons", "<b>Custom Buttons", () => true);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d2 = new ModConfigurationKey<dummy>("   ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<float3> _ButtonSize = new ModConfigurationKey<float3>("ButtonSize", "Button Size - Width, Hight, Thickness", () => _DefultButtonSize);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d5 = new ModConfigurationKey<dummy>("    ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<float> _Buttonslant = new ModConfigurationKey<float>("ButtonSlant", "Button Slant - Makes it look all ugly slanted like that old neos ui", () => 50);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d6 = new ModConfigurationKey<dummy>("     ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<colorX> _Buttoncolor = new ModConfigurationKey<colorX>("ButtonColour", "Button colour", () => new colorX(new color(1, 0, 0, 1)));

        // button

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d3 = new ModConfigurationKey<dummy>("      ", "------------------------------------------------------------------------------------------------------------------------------------------");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d4 = new ModConfigurationKey<dummy>("       ", "");

        //checkbox

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<bool> _customheckbox = new ModConfigurationKey<bool>("Checkbox", "<b>Custom CheckBoxes", () => true);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d7 = new ModConfigurationKey<dummy>("        ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<float> _CheckboxSize = new ModConfigurationKey<float>("CheckBoxSize", "CheckBox Size", () => _DefultCheckboxsize);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d9 = new ModConfigurationKey<dummy>("         ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<float> _CheckboxBevelPercent = new ModConfigurationKey<float>("CheckBoxPercent", "CheckBox Bevel Percent", () => _DefultCheckboxBevel);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d8 = new ModConfigurationKey<dummy>("          ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<colorX> _Checkboxcolor = new ModConfigurationKey<colorX>("CheckBoxColour", "CheckBox colour", () => new colorX(new color(1, 1, 0, 1)));


        //checkbox

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d11 = new ModConfigurationKey<dummy>("           ", "------------------------------------------------------------------------------------------------------------------------------------------");
                                                                                                          
        [AutoRegisterConfigKey]                                                                           
        public static readonly ModConfigurationKey<dummy> _d10 = new ModConfigurationKey<dummy>("            ", "");

        //Slider

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<bool> _customSliders = new ModConfigurationKey<bool>("Slider", "<b>Custom Sliders", () => true);

//        [AutoRegisterConfigKey]
//        public static readonly ModConfigurationKey<dummy> _d12 = new ModConfigurationKey<dummy>("             ", "");
//
//        [AutoRegisterConfigKey]
//        public static readonly ModConfigurationKey<float3> _SliderSize = new ModConfigurationKey<float3>("SliderSize", "Slider Size - Width, Hight, Thickness", () => _DefultButtonSize);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d13 = new ModConfigurationKey<dummy>("              ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<float> _SliderSlant = new ModConfigurationKey<float>("SliderSlant", "Slider Slant", () => _DefultSliderSlant);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d14 = new ModConfigurationKey<dummy>("               ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<colorX> _SliderColor = new ModConfigurationKey<colorX>("SliderColour", "Slider colour", () => new colorX(new color(1, 0, 1, 1)));

        //Slider

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d15 = new ModConfigurationKey<dummy>("                ", "------------------------------------------------------------------------------------------------------------------------------------------");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d16 = new ModConfigurationKey<dummy>("                 ", "");

        //Numeric UpDown

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<bool> _customNumericUpDown = new ModConfigurationKey<bool>("NumericUpDown", "<b>Custom Numeric UpDowns", () => true);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d17 = new ModConfigurationKey<dummy>("                  ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<float> _NumericUpDownSlant = new ModConfigurationKey<float>("NumericUpDownSlant", "Numeric UpDown Slant", () => 0);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d18 = new ModConfigurationKey<dummy>("                   ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<colorX> _NumericUpDownColor = new ModConfigurationKey<colorX>("NumericUpDownColour", "Numeric UpDown colour", () => new colorX(new color(0, 0, 1, 1)));

        //Numeric UpDown

        [AutoRegisterConfigKey]  
        public static readonly ModConfigurationKey<dummy> _d19 = new ModConfigurationKey<dummy>("                    ", "------------------------------------------------------------------------------------------------------------------------------------------");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d20 = new ModConfigurationKey<dummy>("                     ", "");

        //ProgressBar

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<bool> _customProgressBar = new ModConfigurationKey<bool>("ProgressBar", "<b>Custom Progress Bars", () => true);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d21 = new ModConfigurationKey<dummy>("                      ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<float> _ProgressBarSlant = new ModConfigurationKey<float>("ProgressBarSlant", "Progress Bar Slant", () => 0);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d22 = new ModConfigurationKey<dummy>("                       ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<colorX> _ProgressBarColor = new ModConfigurationKey<colorX>("ProgressBarContainerColour", "Progress Bar Container colour", () => new colorX(new color(0, 1, 0, 1)));

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<colorX> _ProgressBarFeildColor = new ModConfigurationKey<colorX>("ProgressBarColour", "Progress Bar colour", () => new colorX(new color(1, 1, 1, 1)));

        //ProgressBar

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d23 = new ModConfigurationKey<dummy>("                        ", "------------------------------------------------------------------------------------------------------------------------------------------");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d24 = new ModConfigurationKey<dummy>("                         ", "");

        //TextFeilds

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<bool> _customTextFeilds = new ModConfigurationKey<bool>("TextFeild", "<b>Custom Text Feilds", () => true);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d25 = new ModConfigurationKey<dummy>("                          ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<float> _TextFeildSlant = new ModConfigurationKey<float>("TextFeildSlant", "Text Feild Slant", () => 0);

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d26 = new ModConfigurationKey<dummy>("                           ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<colorX> _TextFeildColor = new ModConfigurationKey<colorX>("TextFeildColour", "Text Feild colour", () => new colorX(new color(0.37f, 0, 1, 1)));

        //TextFeilds

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d27 = new ModConfigurationKey<dummy>("                            ", "");

        [AutoRegisterConfigKey]
        public static readonly ModConfigurationKey<dummy> _d28 = new ModConfigurationKey<dummy>("                             ", "");

        public override void OnEngineInit() {

            Config = GetConfiguration();
            Config.Save(true);
            Harmony harmony = new Harmony("com.HamoCorp.CustomLegacyUI");
            harmony.PatchAll();

            Debug("CustomLegacyUI Mod is running");
        }

        [HarmonyPatch]
        class LegacyUIPogPatch {

            [HarmonyPrefix]
            [HarmonyPatch(typeof(LegacyButton), "OnAttach")]
            public static bool ButtonEdit(LegacyButton __instance) {

                if (Config.GetValue(_enabled)) {
                    if (Config.GetValue(_customButtons)) {
                        __instance.Size = Config.GetValue(_ButtonSize);
                        __instance.Slant = Config.GetValue(_Buttonslant);
                        __instance.Color = Config.GetValue(_Buttoncolor);
                    }
                }
                return true;
            }

            [HarmonyPrefix]
            [HarmonyPatch(typeof(LegacyCheckbox), "OnAttach")]
            public static bool CheckBoxEdit(LegacyCheckbox __instance) {

                if (Config.GetValue(_enabled)) {
                    if (Config.GetValue(_customheckbox)) {
                        __instance.Size = Config.GetValue(_CheckboxSize);
                        __instance.BevelPercent = Config.GetValue(_CheckboxBevelPercent);
                        __instance.OverrideColor = Config.GetValue(_Checkboxcolor);
                    }
                }
                return true;
            }

            [HarmonyPrefix]
            [HarmonyPatch(typeof(LegacySlider), "OnAttach")]
            public static bool SliderEdit(LegacySlider __instance) {

                if (Config.GetValue(_enabled)) {
                    if (Config.GetValue(_customSliders)) {
 //                       __instance.Thickness = Config.GetValue(_SliderSize.);
                        __instance.Slant = Config.GetValue(_SliderSlant);
                        __instance.OverrideColor = Config.GetValue(_SliderColor);


                    }
                }
                return true;
            }

            [HarmonyPrefix]
            [HarmonyPatch(typeof(LegacyNumericUpDown), "OnAttach")]
            public static bool SliderEdit(LegacyNumericUpDown __instance) {

                if (Config.GetValue(_enabled)) {
                    if (Config.GetValue(_customNumericUpDown)) {
                        __instance.Slant = Config.GetValue(_NumericUpDownSlant);
                        __instance.OverrideColor = Config.GetValue(_NumericUpDownColor);


                    }
                }
                return true;
            }

            [HarmonyPrefix]
            [HarmonyPatch(typeof(LegacyProgressBar), "OnAttach")]
            public static bool ProgressBarEdit(LegacyProgressBar __instance) {

                if (Config.GetValue(_enabled)) {
                    if (Config.GetValue(_customProgressBar)) {
                        __instance.Slant = Config.GetValue(_ProgressBarSlant);
                        __instance.ContainerColor = Config.GetValue(_ProgressBarColor);
                        __instance.BarColor = Config.GetValue(_ProgressBarFeildColor);
                    }
                }
                return true;
            }

            [HarmonyPrefix]
            [HarmonyPatch(typeof(LegacyTextField), "OnAttach")]
            public static bool TextFieldEdit(LegacyTextField __instance) {

                if (Config.GetValue(_enabled)) {
                    if (Config.GetValue(_customTextFeilds)) {
                        __instance.Slant = Config.GetValue(_TextFeildSlant);
                        __instance.OverrideColor = Config.GetValue(_TextFeildColor);
                    }
                }
                return true;
            }

        }
    }
}

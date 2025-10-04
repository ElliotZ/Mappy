﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Numerics;
using System.Text.Json.Serialization;
using Dalamud.Interface;
using KamiLib.Configuration;

namespace Mappy.Data;

public enum CenterTarget
{
    [Description("禁用")]
    Disabled = 0,

    [Description("玩家")]
    Player = 1,

    [Description("地图")]
    Map = 2,
}

[Flags]
public enum FadeMode
{
    [Description("总是")]
    Always = 1 << 0,

    [Description("仅移动时")]
    WhenMoving = 1 << 2,

    [Description("仅聚焦时")]
    WhenFocused = 1 << 3,

    [Description("仅未聚焦时")]
    WhenUnFocused = 1 << 4,
}

public enum AnchorPoint
{
    [Description("左上")]
    UpperLeft = 0,
    [Description("右上")]
    UpperRight = 1,
    [Description("左下")]
    LowerLeft = 2,
    [Description("右下")]
    LowerRight = 3,

}

public class SystemConfig : CharacterConfiguration
{
    public bool UseLinearZoom = false;
    public float ZoomSpeed = 0.25f;
    public float IconScale = 0.50f;
    public bool ShowMiscTooltips = true;
    public bool HideWithGameGui = true;
    public bool HideBetweenAreas = false;
    public bool HideInCombat = false;
    public bool KeepOpen = false;
    public bool FollowOnOpen = false;
    public bool FollowPlayer = true;
    public CenterTarget CenterOnOpen = CenterTarget.Disabled;
    public bool ScalePlayerCone = false;
    public float ConeSize = 150.0f;
    public bool ShowRadar = true;
    public bool ShowRadarInDuties = false;
    public Vector4 RadarColor = KnownColor.Gray.Vector() with { W = 0.10f };
    public Vector4 RadarOutlineColor = KnownColor.Gray.Vector() with { W = 0.30f };
    public bool HideWindowFrame = false;
    public bool HideWindowBackground = false;
    public bool EnableShiftDragMove = false;
    public bool LockWindow = false;
    public float FadePercent = 0.60f;
    public FadeMode FadeMode = FadeMode.WhenUnFocused | FadeMode.WhenMoving;
    public Vector2 WindowPosition = new(1024.0f, 700.0f);
    public Vector2 WindowSize = new(500.0f, 500.0f);
    public bool AlwaysShowToolbar = false;
    public bool ShowToolbarOnHover = true;
    public bool ScaleWithZoom = true;
    public bool AcceptedSpoilerWarning = false;
    public Vector4 AreaColor = KnownColor.CornflowerBlue.Vector() with { W = 0.33f };
    public Vector4 AreaOutlineColor = KnownColor.CornflowerBlue.Vector() with { W = 0.30f };
    public Vector4 PlayerConeColor = KnownColor.CornflowerBlue.Vector() with { W = 0.33f };
    public Vector4 PlayerConeOutlineColor = KnownColor.CornflowerBlue.Vector() with { W = 1.0f };
    public bool CenterOnFlag = true;
    public bool CenterOnGathering = true;
    public bool CenterOnQuest = true;
    public bool LockCenterOnMap = false;
    public bool ShowCoordinateBar = true;
    public float ToolbarFade = 0.33f;
    public float CoordinateBarFade = 0.66f;
    public Vector4 CoordinateTextColor = KnownColor.White.Vector();
    public bool ZoomLocked = false;
    public bool ShowPlayers = true;
    public bool SetFlagOnFateClick = false;
    public bool ShowPlayerIcon = true;
    public float PlayerIconScale = 1.0f;
    public float MapScale = 1.0f;
    public bool AutoZoom = false;
    public bool ShowRegionLabel = true;
    public bool ShowMapLabel = true;
    public bool ShowAreaLabel = true;
    public bool ShowSubAreaLabel = true;
    public bool NoFocusOnAppear = false;
    public float LargeAreaTextScale = 1.5f;
    public float SmallAreaTextScale = 1.0f;
    public bool ShowTextLabels = true;
    public bool ShowFogOfWar = true;
    public bool ScaleTextWithZoom = true;
    public float AutoZoomScaleFactor = 0.33f;
    public float WindowBgFadePercent = 0.30f;
    public int AnchorPoint = 3;
    public Vector2 ToggledWindowSize = new(500f, 500f);

    // Do not persist this setting
    [JsonIgnore]
    public bool DebugMode = false;

    public static SystemConfig Load() => Service.PluginInterface.LoadConfigFile<SystemConfig>("System.config.json");

    public static void Save() => Service.PluginInterface.SaveConfigFile("System.config.json", System.SystemConfig);
}
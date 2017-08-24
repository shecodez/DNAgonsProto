// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.33 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.33;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:False,bkdf:True,hqlp:False,rprd:True,enco:True,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:66,x:32977,y:32223,varname:node_66,prsc:2|diff-1476-OUT,spec-717-OUT,gloss-2171-OUT;n:type:ShaderForge.SFN_TexCoord,id:4940,x:30409,y:32571,varname:node_4940,prsc:2,uv:0;n:type:ShaderForge.SFN_Color,id:3580,x:31592,y:31909,ptovrint:False,ptlb:Color1,ptin:_Color1,varname:node_3580,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:717,x:32535,y:32506,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_717,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5393327,max:1;n:type:ShaderForge.SFN_Slider,id:2171,x:32535,y:32605,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_2171,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2680299,max:1;n:type:ShaderForge.SFN_Multiply,id:5968,x:31639,y:32647,varname:node_5968,prsc:2|A-1585-OUT,B-5184-OUT;n:type:ShaderForge.SFN_Step,id:1585,x:31356,y:32648,varname:node_1585,prsc:2|A-1678-OUT,B-1126-OUT;n:type:ShaderForge.SFN_Vector1,id:1126,x:31060,y:32703,varname:node_1126,prsc:2,v1:0.25;n:type:ShaderForge.SFN_Vector1,id:3420,x:30389,y:32845,varname:node_3420,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Step,id:5721,x:30578,y:32845,varname:node_5721,prsc:2|A-3420-OUT,B-130-OUT;n:type:ShaderForge.SFN_Multiply,id:9014,x:31633,y:32077,varname:node_9014,prsc:2|A-3580-RGB,B-5435-OUT;n:type:ShaderForge.SFN_Set,id:1688,x:30592,y:32569,varname:U,prsc:2|IN-4940-U;n:type:ShaderForge.SFN_Set,id:8853,x:30592,y:32617,varname:V,prsc:2|IN-4940-V;n:type:ShaderForge.SFN_Get,id:1678,x:31039,y:32648,varname:node_1678,prsc:2|IN-1688-OUT;n:type:ShaderForge.SFN_Get,id:130,x:30389,y:32900,varname:node_130,prsc:2|IN-8853-OUT;n:type:ShaderForge.SFN_Step,id:6464,x:31060,y:32781,varname:node_6464,prsc:2|A-9207-OUT,B-8974-OUT;n:type:ShaderForge.SFN_Get,id:9207,x:30872,y:32781,varname:node_9207,prsc:2|IN-1688-OUT;n:type:ShaderForge.SFN_Vector1,id:8974,x:30893,y:32843,varname:node_8974,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Subtract,id:2748,x:31356,y:32785,varname:node_2748,prsc:2|A-6464-OUT,B-1585-OUT;n:type:ShaderForge.SFN_RemapRange,id:8807,x:30578,y:33001,varname:node_8807,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0|IN-5721-OUT;n:type:ShaderForge.SFN_Color,id:1382,x:31816,y:31909,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:_Color2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.2551723,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:4274,x:31854,y:32077,varname:node_4274,prsc:2|A-1382-RGB,B-6013-OUT;n:type:ShaderForge.SFN_Add,id:7525,x:32520,y:32081,varname:node_7525,prsc:2|A-9014-OUT,B-4274-OUT,C-1276-OUT,D-2937-OUT;n:type:ShaderForge.SFN_Color,id:6547,x:31832,y:32484,ptovrint:False,ptlb:Color6,ptin:_Color6,varname:_Color3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7352941,c2:0.3243945,c3:0.723959,c4:1;n:type:ShaderForge.SFN_Multiply,id:5003,x:31833,y:32325,varname:node_5003,prsc:2|A-6547-RGB,B-515-OUT;n:type:ShaderForge.SFN_Color,id:8416,x:31633,y:32484,ptovrint:False,ptlb:Color5,ptin:_Color5,varname:_Color4,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9736309,c3:0.04411763,c4:1;n:type:ShaderForge.SFN_Multiply,id:7029,x:32024,y:32647,varname:node_7029,prsc:2|A-1585-OUT,B-9613-OUT;n:type:ShaderForge.SFN_Multiply,id:2158,x:31633,y:32325,varname:node_2158,prsc:2|A-8416-RGB,B-8358-OUT;n:type:ShaderForge.SFN_Multiply,id:255,x:32024,y:32784,varname:node_255,prsc:2|A-9613-OUT,B-2748-OUT;n:type:ShaderForge.SFN_Multiply,id:2577,x:31639,y:32784,varname:node_2577,prsc:2|A-2748-OUT,B-5184-OUT;n:type:ShaderForge.SFN_Get,id:8372,x:30872,y:32996,varname:node_8372,prsc:2|IN-1688-OUT;n:type:ShaderForge.SFN_Vector1,id:4300,x:30893,y:33055,varname:node_4300,prsc:2,v1:0.75;n:type:ShaderForge.SFN_Step,id:1467,x:31060,y:32996,varname:node_1467,prsc:2|A-8372-OUT,B-4300-OUT;n:type:ShaderForge.SFN_Subtract,id:6952,x:31356,y:32922,varname:node_6952,prsc:2|A-1467-OUT,B-6464-OUT;n:type:ShaderForge.SFN_Multiply,id:5037,x:32024,y:32920,varname:node_5037,prsc:2|A-6952-OUT,B-9613-OUT;n:type:ShaderForge.SFN_Multiply,id:2886,x:31639,y:32920,varname:node_2886,prsc:2|A-5184-OUT,B-6952-OUT;n:type:ShaderForge.SFN_Multiply,id:3991,x:32015,y:32325,varname:node_3991,prsc:2|A-3028-OUT,B-3019-RGB;n:type:ShaderForge.SFN_Color,id:3019,x:32024,y:32484,ptovrint:False,ptlb:Color7,ptin:_Color7,varname:node_3019,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.09571119,c2:0.6985294,c3:0.04622621,c4:1;n:type:ShaderForge.SFN_Color,id:9588,x:32032,y:31909,ptovrint:False,ptlb:Color3,ptin:_Color3,varname:_Color6,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.04411763,c2:0.8417854,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:1276,x:32036,y:32077,varname:node_1276,prsc:2|A-9588-RGB,B-6132-OUT;n:type:ShaderForge.SFN_Add,id:1476,x:32738,y:32182,varname:node_1476,prsc:2|A-7525-OUT,B-4724-OUT;n:type:ShaderForge.SFN_Add,id:4724,x:32520,y:32328,varname:node_4724,prsc:2|A-2158-OUT,B-5003-OUT,C-3991-OUT,D-7999-OUT;n:type:ShaderForge.SFN_RemapRange,id:8822,x:31356,y:33049,varname:node_8822,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0|IN-1467-OUT;n:type:ShaderForge.SFN_Color,id:3249,x:32242,y:31909,ptovrint:False,ptlb:Color4,ptin:_Color4,varname:_Color7,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.6827586,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:7213,x:32246,y:32484,ptovrint:False,ptlb:Color8,ptin:_Color8,varname:_Color8,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4999999,c2:0.375,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:4720,x:31639,y:33066,varname:node_4720,prsc:2|A-8822-OUT,B-5184-OUT;n:type:ShaderForge.SFN_Multiply,id:2937,x:32246,y:32077,varname:node_2937,prsc:2|A-3249-RGB,B-4028-OUT;n:type:ShaderForge.SFN_Multiply,id:5433,x:32024,y:33066,varname:node_5433,prsc:2|A-8822-OUT,B-9613-OUT;n:type:ShaderForge.SFN_Multiply,id:7999,x:32246,y:32325,varname:node_7999,prsc:2|A-7213-RGB,B-8650-OUT;n:type:ShaderForge.SFN_Set,id:7215,x:30758,y:32915,varname:UPSide,prsc:2|IN-5721-OUT;n:type:ShaderForge.SFN_Set,id:6605,x:30758,y:33055,varname:DownSide,prsc:2|IN-8807-OUT;n:type:ShaderForge.SFN_Get,id:5184,x:31356,y:32583,varname:node_5184,prsc:2|IN-7215-OUT;n:type:ShaderForge.SFN_Get,id:9613,x:31826,y:32856,varname:node_9613,prsc:2|IN-6605-OUT;n:type:ShaderForge.SFN_Set,id:6495,x:31832,y:32647,varname:Slot1,prsc:2|IN-5968-OUT;n:type:ShaderForge.SFN_Set,id:1172,x:31832,y:32784,varname:Slot2,prsc:2|IN-2577-OUT;n:type:ShaderForge.SFN_Set,id:9709,x:31832,y:32920,varname:Slot3,prsc:2|IN-2886-OUT;n:type:ShaderForge.SFN_Set,id:3411,x:31832,y:33066,varname:Slot4,prsc:2|IN-4720-OUT;n:type:ShaderForge.SFN_Get,id:5435,x:31612,y:32209,varname:node_5435,prsc:2|IN-6495-OUT;n:type:ShaderForge.SFN_Get,id:6013,x:31833,y:32209,varname:node_6013,prsc:2|IN-1172-OUT;n:type:ShaderForge.SFN_Get,id:6132,x:32015,y:32209,varname:node_6132,prsc:2|IN-9709-OUT;n:type:ShaderForge.SFN_Get,id:4028,x:32225,y:32209,varname:node_4028,prsc:2|IN-3411-OUT;n:type:ShaderForge.SFN_Set,id:5764,x:32191,y:32647,varname:Slot5,prsc:2|IN-7029-OUT;n:type:ShaderForge.SFN_Set,id:8352,x:32191,y:32784,varname:Slot6,prsc:2|IN-255-OUT;n:type:ShaderForge.SFN_Set,id:1254,x:32191,y:32920,varname:Slot7,prsc:2|IN-5037-OUT;n:type:ShaderForge.SFN_Set,id:7672,x:32191,y:33066,varname:Slot8,prsc:2|IN-5433-OUT;n:type:ShaderForge.SFN_Get,id:8358,x:31612,y:32267,varname:node_8358,prsc:2|IN-5764-OUT;n:type:ShaderForge.SFN_Get,id:515,x:31833,y:32267,varname:node_515,prsc:2|IN-8352-OUT;n:type:ShaderForge.SFN_Get,id:3028,x:32015,y:32267,varname:node_3028,prsc:2|IN-1254-OUT;n:type:ShaderForge.SFN_Get,id:8650,x:32225,y:32267,varname:node_8650,prsc:2|IN-7672-OUT;proporder:3580-1382-9588-3249-8416-6547-3019-7213-717-2171;pass:END;sub:END;*/

Shader "Malbers/Colors8" {
    Properties {
        _Color1 ("Color1", Color) = (1,0,0,1)
        _Color2 ("Color2", Color) = (0,0.2551723,1,1)
        _Color3 ("Color3", Color) = (0.04411763,0.8417854,1,1)
        _Color4 ("Color4", Color) = (1,0.6827586,0,1)
        _Color5 ("Color5", Color) = (1,0.9736309,0.04411763,1)
        _Color6 ("Color6", Color) = (0.7352941,0.3243945,0.723959,1)
        _Color7 ("Color7", Color) = (0.09571119,0.6985294,0.04622621,1)
        _Color8 ("Color8", Color) = (0.4999999,0.375,1,1)
        _Specular ("Specular", Range(0, 1)) = 0.5393327
        _Gloss ("Gloss", Range(0, 1)) = 0.2680299
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _Color1;
            uniform float _Specular;
            uniform float _Gloss;
            uniform float4 _Color2;
            uniform float4 _Color6;
            uniform float4 _Color5;
            uniform float4 _Color7;
            uniform float4 _Color3;
            uniform float4 _Color4;
            uniform float4 _Color8;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Specular;
                float specularMonochrome;
                float U = i.uv0.r;
                float node_1585 = step(U,0.25);
                float V = i.uv0.g;
                float node_5721 = step(0.5,V);
                float UPSide = node_5721;
                float node_5184 = UPSide;
                float Slot1 = (node_1585*node_5184);
                float node_6464 = step(U,0.5);
                float node_2748 = (node_6464-node_1585);
                float Slot2 = (node_2748*node_5184);
                float node_1467 = step(U,0.75);
                float node_6952 = (node_1467-node_6464);
                float Slot3 = (node_5184*node_6952);
                float node_8822 = (node_1467*-1.0+1.0);
                float Slot4 = (node_8822*node_5184);
                float DownSide = (node_5721*-1.0+1.0);
                float node_9613 = DownSide;
                float Slot5 = (node_1585*node_9613);
                float Slot6 = (node_9613*node_2748);
                float Slot7 = (node_6952*node_9613);
                float Slot8 = (node_8822*node_9613);
                float3 diffuseColor = (((_Color1.rgb*Slot1)+(_Color2.rgb*Slot2)+(_Color3.rgb*Slot3)+(_Color4.rgb*Slot4))+((_Color5.rgb*Slot5)+(_Color6.rgb*Slot6)+(Slot7*_Color7.rgb)+(_Color8.rgb*Slot8))); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _Color1;
            uniform float _Specular;
            uniform float _Gloss;
            uniform float4 _Color2;
            uniform float4 _Color6;
            uniform float4 _Color5;
            uniform float4 _Color7;
            uniform float4 _Color3;
            uniform float4 _Color4;
            uniform float4 _Color8;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos(v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Gloss;
                float perceptualRoughness = 1.0 - _Gloss;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Specular;
                float specularMonochrome;
                float U = i.uv0.r;
                float node_1585 = step(U,0.25);
                float V = i.uv0.g;
                float node_5721 = step(0.5,V);
                float UPSide = node_5721;
                float node_5184 = UPSide;
                float Slot1 = (node_1585*node_5184);
                float node_6464 = step(U,0.5);
                float node_2748 = (node_6464-node_1585);
                float Slot2 = (node_2748*node_5184);
                float node_1467 = step(U,0.75);
                float node_6952 = (node_1467-node_6464);
                float Slot3 = (node_5184*node_6952);
                float node_8822 = (node_1467*-1.0+1.0);
                float Slot4 = (node_8822*node_5184);
                float DownSide = (node_5721*-1.0+1.0);
                float node_9613 = DownSide;
                float Slot5 = (node_1585*node_9613);
                float Slot6 = (node_9613*node_2748);
                float Slot7 = (node_6952*node_9613);
                float Slot8 = (node_8822*node_9613);
                float3 diffuseColor = (((_Color1.rgb*Slot1)+(_Color2.rgb*Slot2)+(_Color3.rgb*Slot3)+(_Color4.rgb*Slot4))+((_Color5.rgb*Slot5)+(_Color6.rgb*Slot6)+(Slot7*_Color7.rgb)+(_Color8.rgb*Slot8))); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform float4 _Color1;
            uniform float _Specular;
            uniform float _Gloss;
            uniform float4 _Color2;
            uniform float4 _Color6;
            uniform float4 _Color5;
            uniform float4 _Color7;
            uniform float4 _Color3;
            uniform float4 _Color4;
            uniform float4 _Color8;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float U = i.uv0.r;
                float node_1585 = step(U,0.25);
                float V = i.uv0.g;
                float node_5721 = step(0.5,V);
                float UPSide = node_5721;
                float node_5184 = UPSide;
                float Slot1 = (node_1585*node_5184);
                float node_6464 = step(U,0.5);
                float node_2748 = (node_6464-node_1585);
                float Slot2 = (node_2748*node_5184);
                float node_1467 = step(U,0.75);
                float node_6952 = (node_1467-node_6464);
                float Slot3 = (node_5184*node_6952);
                float node_8822 = (node_1467*-1.0+1.0);
                float Slot4 = (node_8822*node_5184);
                float DownSide = (node_5721*-1.0+1.0);
                float node_9613 = DownSide;
                float Slot5 = (node_1585*node_9613);
                float Slot6 = (node_9613*node_2748);
                float Slot7 = (node_6952*node_9613);
                float Slot8 = (node_8822*node_9613);
                float3 diffColor = (((_Color1.rgb*Slot1)+(_Color2.rgb*Slot2)+(_Color3.rgb*Slot3)+(_Color4.rgb*Slot4))+((_Color5.rgb*Slot5)+(_Color6.rgb*Slot6)+(Slot7*_Color7.rgb)+(_Color8.rgb*Slot8)));
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Specular, specColor, specularMonochrome );
                float roughness = 1.0 - _Gloss;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using AimsharpWow.API; //needed to access Aimsharp API

namespace AimsharpWow.Modules
{
/// <summary>
/// From Kaneto:
/// I used this rotation to create a better one for Prot Warriors. Feedback to xKaneto on Discord.
/// V1.4.4
/// </summary>

public class KanetoProtectionWarrior : Rotation
{
    #region SpellFunctions
    private static string Heroism_SpellName()
    {
        // spell=32182
        switch (Language)
        {
        case "English":
            return "Heroism";
        case "Deutsch":
            return "Heldentum";
        case "Español":
            return "Heroísmo";
        case "Français":
            return "Héroïsme";
        case "Italiano":
            return "Eroismo";
        case "Português Brasileiro":
            return "Heroísmo";
        case "Русский":
            return "Героизм";
        case "한국어":
            return "영웅심";
        case "简体中文":
            return "英勇";
        default:
            return "Heroism";
        }
    }

    private static string Revenge_SpellName()
    {
        // spell=6572
        switch (Language)
        {
        case "English":
            return "Revenge";
        case "Deutsch":
            return "Rache";
        case "Español":
            return "Revancha";
        case "Français":
            return "Revanche";
        case "Italiano":
            return "Rivincita";
        case "Português Brasileiro":
            return "Revanche";
        case "Русский":
            return "Реванш";
        case "한국어":
            return "복수";
        case "简体中文":
            return "复仇";
        default:
            return "Revenge";
        }
    }

    private static string Healthstone_SpellName()
    {
        // item=5512
        switch (Language)
        {
        case "English":
            return "Healthstone";
        case "Deutsch":
            return "Gesundheitsstein";
        case "Español":
            return "Piedra de salud";
        case "Français":
            return "Pierre de soins";
        case "Italiano":
            return "Pietra della Salute";
        case "Português Brasileiro":
            return "Pedra de Vida";
        case "Русский":
            return "Камень здоровья";
        case "한국어":
            return "생명석";
        case "简体中文":
            return "治疗石";
        default:
            return "Healthstone";
        }
    }

    private static string Intervene_SpellName()
    {
        // spell=3411
        switch (Language)
        {
        case "English":
            return "Intervene";
        case "Deutsch":
            return "Einschreiten";
        case "Español":
            return "Intervenir";
        case "Français":
            return "Intervention";
        case "Italiano":
            return "Intervento";
        case "Português Brasileiro":
            return "Comprar Briga";
        case "Русский":
            return "Вмешательство";
        case "한국어":
            return "가로막기";
        case "简体中文":
            return "援护";
        default:
            return "Intervene";
        }
    }

    private static string Charge_SpellName()
    {
        // spell=100
        switch (Language)
        {
        case "English":
            return "Charge";
        case "Deutsch":
            return "Sturmangriff";
        case "Español":
            return "Cargar";
        case "Français":
            return "Charge";
        case "Italiano":
            return "Carica";
        case "Português Brasileiro":
            return "Investida";
        case "Русский":
            return "Рывок";
        case "한국어":
            return "돌진";
        case "简体中文":
            return "冲锋";
        default:
            return "Charge";
        }
    }

    private static string Taunt_SpellName()
    {
        // spell=355
        switch (Language)
        {
        case "English":
            return "Taunt";
        case "Deutsch":
            return "Spott";
        case "Español":
            return "Provocar";
        case "Français":
            return "Provocation";
        case "Italiano":
            return "Provocazione";
        case "Português Brasileiro":
            return "Provocar";
        case "Русский":
            return "Провокация";
        case "한국어":
            return "도발";
        case "简体中文":
            return "嘲讽";
        default:
            return "Taunt";
        }
    }

    private static string StormBolt_SpellName()
    {
        // spell=107570
        switch (Language)
        {
        case "English":
            return "Storm Bolt";
        case "Deutsch":
            return "Sturmblitz";
        case "Español":
            return "Descarga tormentosa";
        case "Français":
            return "Éclair de tempête";
        case "Italiano":
            return "Dardo della Tempesta";
        case "Português Brasileiro":
            return "Seta Tempestuosa";
        case "Русский":
            return "Удар громовержца";
        case "한국어":
            return "폭풍망치";
        case "简体中文":
            return "风暴之锤";
        default:
            return "Storm Bolt";
        }
    }

    private static string RallyingCry_SpellName()
    {
        // spell=97462
        switch (Language)
        {
        case "English":
            return "Rallying Cry";
        case "Deutsch":
            return "Anspornender Schrei";
        case "Español":
            return "Berrido de convocación";
        case "Français":
            return "Cri de ralliement";
        case "Italiano":
            return "Chiamata a Raccolta";
        case "Português Brasileiro":
            return "Brado de Convocação";
        case "Русский":
            return "Ободряющий клич";
        case "한국어":
            return "재집결의 함성";
        case "简体中文":
            return "集结呐喊";
        default:
            return "Rallying Cry";
        }
    }

    private static string IntimidatingShout_SpellName()
    {
        // spell=5246
        switch (Language)
        {
        case "English":
            return "Intimidating Shout";
        case "Deutsch":
            return "Drohruf";
        case "Español":
            return "Grito intimidador";
        case "Français":
            return "Cri d’intimidation";
        case "Italiano":
            return "Urlo Intimidatorio";
        case "Português Brasileiro":
            return "Brado Intimidador";
        case "Русский":
            return "Устрашающий крик";
        case "한국어":
            return "위협의 외침";
        case "简体中文":
            return "破胆怒吼";
        default:
            return "Intimidating Shout";
        }
    }

    private static string Shockwave_SpellName()
    {
        // spell=46968
        switch (Language)
        {
        case "English":
            return "Shockwave";
        case "Deutsch":
            return "Schockwelle";
        case "Español":
            return "Ola de choque";
        case "Français":
            return "Onde de choc";
        case "Italiano":
            return "Onda d'Urto";
        case "Português Brasileiro":
            return "Onda de Choque";
        case "Русский":
            return "Ударная волна";
        case "한국어":
            return "충격파";
        case "简体中文":
            return "震荡波";
        default:
            return "Shockwave";
        }
    }

    private static string ShatteringThrow_SpellName()
    {
        // spell=64382
        switch (Language)
        {
        case "English":
            return "Shattering Throw";
        case "Deutsch":
            return "Zerschmetternder Wurf";
        case "Español":
            return "Lanzamiento destrozador";
        case "Français":
            return "Lancer fracassant";
        case "Italiano":
            return "Lancio Frantumante";
        case "Português Brasileiro":
            return "Arremesso Estilhaçante";
        case "Русский":
            return "Сокрушительный бросок";
        case "한국어":
            return "분쇄의 투척";
        case "简体中文":
            return "碎裂投掷";
        default:
            return "Shattering Throw";
        }
    }

    private static string BloodFury_SpellName()
    {
        // spell=33697
        switch (Language)
        {
        case "English":
            return "Blood Fury";
        case "Deutsch":
            return "Kochendes Blut";
        case "Español":
            return "Furia sangrienta";
        case "Français":
            return "Fureur sanguinaire";
        case "Italiano":
            return "Furia Sanguinaria";
        case "Português Brasileiro":
            return "Fúria Sangrenta";
        case "Русский":
            return "Кровавое неистовство";
        case "한국어":
            return "피의 격노";
        case "简体中文":
            return "血性狂怒";
        default:
            return "Blood Fury";
        }
    }

    private static string Berserking_SpellName()
    {
        // spell=26297
        switch (Language)
        {
        case "English":
            return "Berserking";
        case "Deutsch":
            return "Berserker";
        case "Español":
            return "Rabiar";
        case "Français":
            return "Berserker";
        case "Italiano":
            return "Berserker";
        case "Português Brasileiro":
            return "Berserk";
        case "Русский":
            return "Берсерк";
        case "한국어":
            return "광폭화";
        case "简体中文":
            return "狂暴";
        default:
            return "Berserking";
        }
    }

    private static string Fireblood_SpellName()
    {
        // spell=265221
        switch (Language)
        {
        case "English":
            return "Fireblood";
        case "Deutsch":
            return "Feuerblut";
        case "Español":
            return "Sangrardiente";
        case "Français":
            return "Sang de feu";
        case "Italiano":
            return "Sangue Infuocato";
        case "Português Brasileiro":
            return "Sangue de Fogo";
        case "Русский":
            return "Огненная кровь";
        case "한국어":
            return "불꽃피";
        case "简体中文":
            return "烈焰之血";
        default:
            return "Fireblood";
        }
    }

    private static string AncestralCall_SpellName()
    {
        // spell=274738
        switch (Language)
        {
        case "English":
            return "Ancestral Call";
        case "Deutsch":
            return "Ruf der Ahnen";
        case "Español":
            return "Llamada ancestral";
        case "Français":
            return "Appel ancestral";
        case "Italiano":
            return "Richiamo Ancestrale";
        case "Português Brasileiro":
            return "Chamado Ancestral";
        case "Русский":
            return "Призыв предков";
        case "한국어":
            return "고대의 부름";
        case "简体中文":
            return "先祖召唤";
        default:
            return "Ancestral Call";
        }
    }

    private static string LightsJudgment_SpellName()
    {
        // spell=255647
        switch (Language)
        {
        case "English":
            return "Light's Judgment";
        case "Deutsch":
            return "Urteil des Lichts";
        case "Español":
            return "Sentencia de la Luz";
        case "Français":
            return "Jugement de la Lumière";
        case "Italiano":
            return "Giudizio della Luce";
        case "Português Brasileiro":
            return "Julgamento da Luz";
        case "Русский":
            return "Правосудие Света";
        case "한국어":
            return "빛의 심판";
        case "简体中文":
            return "圣光裁决者";
        default:
            return "Light's Judgment";
        }
    }

    private static string ArcaneTorrent_SpellName()
    {
        // spell=28730
        switch (Language)
        {
        case "English":
            return "Arcane Torrent";
        case "Deutsch":
            return "Arkaner Strom";
        case "Español":
            return "Torrente Arcano";
        case "Français":
            return "Torrent arcanique";
        case "Italiano":
            return "Torrente Arcano";
        case "Português Brasileiro":
            return "Torrente Arcana";
        case "Русский":
            return "Волшебный поток";
        case "한국어":
            return "비전 격류";
        case "简体中文":
            return "奥术洪流";
        default:
            return "Arcane Torrent";
        }
    }

    private static string WarStomp_SpellName()
    {
        // spell=20549
        switch (Language)
        {
        case "English":
            return "War Stomp";
        case "Deutsch":
            return "Kriegsdonner";
        case "Español":
            return "Pisotón de guerra";
        case "Français":
            return "Choc martial";
        case "Italiano":
            return "Zoccolo di Guerra";
        case "Português Brasileiro":
            return "Pisada de Guerra";
        case "Русский":
            return "Громовая поступь";
        case "한국어":
            return "전투 발구르기";
        case "简体中文":
            return "战争践踏";
        default:
            return "War Stomp";
        }
    }

    private static string BagofTricks_SpellName()
    {
        // spell=312411
        switch (Language)
        {
        case "English":
            return "Bag of Tricks";
        case "Deutsch":
            return "Trickkiste";
        case "Español":
            return "Bolsa de trucos";
        case "Français":
            return "Sac à malice";
        case "Italiano":
            return "Borsa di Trucchi";
        case "Português Brasileiro":
            return "Bolsa de Truques";
        case "Русский":
            return "Набор хитростей";
        case "한국어":
            return "비장의 묘수";
        case "简体中文":
            return "袋里乾坤";
        default:
            return "Bag of Tricks";
        }
    }

    private static string Avatar_SpellName()
    {
        // spell=163249
        switch (Language)
        {
        case "English":
            return "Avatar";
        case "Deutsch":
            return "Avatar";
        case "Español":
            return "Avatar";
        case "Français":
            return "Avatar";
        case "Italiano":
            return "Avatar";
        case "Português Brasileiro":
            return "Avatar";
        case "Русский":
            return "Аватара";
        case "한국어":
            return "투신";
        case "简体中文":
            return "天神下凡";
        default:
            return "Avatar";
        }
    }

    private static string IgnorePain_SpellName()
    {
        // spell=190456
        switch (Language)
        {
        case "English":
            return "Ignore Pain";
        case "Deutsch":
            return "Zähne zusammenbeißen";
        case "Español":
            return "Ignorar dolor";
        case "Français":
            return "Dur au mal";
        case "Italiano":
            return "Insensibilità";
        case "Português Brasileiro":
            return "Ignorar Dor";
        case "Русский":
            return "Стойкость к боли";
        case "한국어":
            return "고통 감내";
        case "简体中文":
            return "无视苦痛";
        default:
            return "Ignore Pain";
        }
    }

    private static string DemoralizingShout_SpellName()
    {
        // spell=1160
        switch (Language)
        {
        case "English":
            return "Demoralizing Shout";
        case "Deutsch":
            return "Demoralisierender Ruf";
        case "Español":
            return "Grito desmoralizador";
        case "Français":
            return "Cri démoralisant";
        case "Italiano":
            return "Urlo Demoralizzante";
        case "Português Brasileiro":
            return "Brado Desmoralizador";
        case "Русский":
            return "Деморализующий крик";
        case "한국어":
            return "사기의 외침";
        case "简体中文":
            return "挫志怒吼";
        default:
            return "Demoralizing Shout";
        }
    }

    private static string LastStand_SpellName()
    {
        // spell=53478
        switch (Language)
        {
        case "English":
            return "Last Stand";
        case "Deutsch":
            return "Letztes Gefecht";
        case "Español":
            return "Última carga";
        case "Français":
            return "Dernier rempart";
        case "Italiano":
            return "Ultima Difesa";
        case "Português Brasileiro":
            return "Último Recurso";
        case "Русский":
            return "Ни шагу назад";
        case "한국어":
            return "최후의 저항";
        case "简体中文":
            return "破釜沉舟";
        default:
            return "Last Stand";
        }
    }

    private static string ThunderClap_SpellName()
    {
        // spell=6343
        switch (Language)
        {
        case "English":
            return "Thunder Clap";
        case "Deutsch":
            return "Donnerknall";
        case "Español":
            return "Atronar";
        case "Français":
            return "Coup de tonnerre";
        case "Italiano":
            return "Schianto del Tuono";
        case "Português Brasileiro":
            return "Trovoada";
        case "Русский":
            return "Удар грома";
        case "한국어":
            return "천둥벼락";
        case "简体中文":
            return "雷霆一击";
        default:
            return "Thunder Clap";
        }
    }

    private static string Ravager_SpellName()
    {
        // spell=152277
        switch (Language)
        {
        case "English":
            return "Ravager";
        case "Deutsch":
            return "Verheerer";
        case "Español":
            return "Devastador";
        case "Français":
            return "Ravageur";
        case "Italiano":
            return "Impeto Devastatore";
        case "Português Brasileiro":
            return "Assolador";
        case "Русский":
            return "Опустошитель";
        case "한국어":
            return "쇠날발톱";
        case "简体中文":
            return "破坏者";
        default:
            return "Ravager";
        }
    }

    private static string ShieldBlock_SpellName()
    {
        // spell=2565
        switch (Language)
        {
        case "English":
            return "Shield Block";
        case "Deutsch":
            return "Schildblock";
        case "Español":
            return "Bloquear con escudo";
        case "Français":
            return "Maîtrise du blocage";
        case "Italiano":
            return "Scudo Saldo";
        case "Português Brasileiro":
            return "Levantar Escudo";
        case "Русский":
            return "Блок щитом";
        case "한국어":
            return "방패 올리기";
        case "简体中文":
            return "盾牌格挡";
        default:
            return "Shield Block";
        }
    }

    private static string ShieldSlam_SpellName()
    {
        // spell=23922
        switch (Language)
        {
        case "English":
            return "Shield Slam";
        case "Deutsch":
            return "Schildschlag";
        case "Español":
            return "Embate con escudo";
        case "Français":
            return "Heurt de bouclier";
        case "Italiano":
            return "Colpo di Scudo";
        case "Português Brasileiro":
            return "Escudada";
        case "Русский":
            return "Мощный удар щитом";
        case "한국어":
            return "방패 밀쳐내기";
        case "简体中文":
            return "盾牌猛击";
        default:
            return "Shield Slam";
        }
    }

    private static string Slam_SpellName()
    {
        // spell=1464
        switch (Language)
        {
        case "English":
            return "Slam";
        case "Deutsch":
            return "Zerschmettern";
        case "Español":
            return "Embate";
        case "Français":
            return "Heurtoir";
        case "Italiano":
            return "Contusione";
        case "Português Brasileiro":
            return "Batida";
        case "Русский":
            return "Мощный удар";
        case "한국어":
            return "격돌";
        case "简体中文":
            return "猛击";
        default:
            return "Slam";
        }
    }

    private static string Devastate_SpellName()
    {
        // spell=20243
        switch (Language)
        {
        case "English":
            return "Devastate";
        case "Deutsch":
            return "Verwüsten";
        case "Español":
            return "Devastar";
        case "Français":
            return "Dévaster";
        case "Italiano":
            return "Sfondamento";
        case "Português Brasileiro":
            return "Devastar";
        case "Русский":
            return "Сокрушение";
        case "한국어":
            return "압도";
        case "简体中文":
            return "毁灭打击";
        default:
            return "Devastate";
        }
    }

    private static string VictoryRush_SpellName()
    {
        // spell=34428
        switch (Language)
        {
        case "English":
            return "Victory Rush";
        case "Deutsch":
            return "Siegesrausch";
        case "Español":
            return "Ataque de la victoria";
        case "Français":
            return "Ivresse de la victoire";
        case "Italiano":
            return "Frenesia di Vittoria";
        case "Português Brasileiro":
            return "Ímpeto da Vitória";
        case "Русский":
            return "Победный раж";
        case "한국어":
            return "연전연승";
        case "简体中文":
            return "乘胜追击";
        default:
            return "Victory Rush";
        }
    }

    private static string ShieldWall_SpellName()
    {
        // spell=871
        switch (Language)
        {
        case "English":
            return "Shield Wall";
        case "Deutsch":
            return "Schildwall";
        case "Español":
            return "Muro de escudo";
        case "Français":
            return "Mur protecteur";
        case "Italiano":
            return "Muro di Scudi";
        case "Português Brasileiro":
            return "Muralha de Escudos";
        case "Русский":
            return "Глухая оборона";
        case "한국어":
            return "방패의 벽";
        case "简体中文":
            return "盾墙";
        default:
            return "Shield Wall";
        }
    }

    private static string BattleShout_SpellName()
    {
        // spell=6673
        switch (Language)
        {
        case "English":
            return "Battle Shout";
        case "Deutsch":
            return "Schlachtruf";
        case "Español":
            return "Grito de batalla";
        case "Français":
            return "Cri de guerre";
        case "Italiano":
            return "Urlo di Battaglia";
        case "Português Brasileiro":
            return "Brado de Batalha";
        case "Русский":
            return "Боевой крик";
        case "한국어":
            return "전투의 외침";
        case "简体中文":
            return "战斗怒吼";
        default:
            return "Battle Shout";
        }
    }

    private static string Pummel_SpellName()
    {
        // spell=6552
        switch (Language)
        {
        case "English":
            return "Pummel";
        case "Deutsch":
            return "Zuschlagen";
        case "Español":
            return "Zurrar";
        case "Français":
            return "Volée de coups";
        case "Italiano":
            return "Pugno Diversivo";
        case "Português Brasileiro":
            return "Murro";
        case "Русский":
            return "Зуботычина";
        case "한국어":
            return "들이치기";
        case "简体中文":
            return "拳击";
        default:
            return "Pummel";
        }
    }

    private static string Execute_SpellName()
    {
        // spell=163201
        switch (Language)
        {
        case "English":
            return "Execute";
        case "Deutsch":
            return "Hinrichten";
        case "Español":
            return "Ejecutar";
        case "Français":
            return "Exécution";
        case "Italiano":
            return "Esecuzione";
        case "Português Brasileiro":
            return "Executar";
        case "Русский":
            return "Казнь";
        case "한국어":
            return "마무리 일격";
        case "简体中文":
            return "斩杀";
        default:
            return "Execute";
        }
    }

    private static string SpearofBastion_SpellName()
    {
        // spell=307865
        switch (Language)
        {
        case "English":
            return "Spear of Bastion";
        case "Deutsch":
            return "Speer der Bastion";
        case "Español":
            return "Lanza de Bastión";
        case "Français":
            return "Lance du Bastion";
        case "Italiano":
            return "Lancia del Bastione";
        case "Português Brasileiro":
            return "Lança do Bastião";
        case "Русский":
            return "Копье Бастиона";
        case "한국어":
            return "보루의 창";
        case "简体中文":
            return "晋升堡垒之矛";
        default:
            return "Spear of Bastion";
        }
    }

    private static string AncientAftershock_SpellName()
    {
        // spell=325886
        switch (Language)
        {
        case "English":
            return "Ancient Aftershock";
        case "Deutsch":
            return "Nachbeben der Ahnen";
        case "Español":
            return "Réplica ancestral";
        case "Français":
            return "Réplique des anciens";
        case "Italiano":
            return "Scossa d'Assestamento Antica";
        case "Português Brasileiro":
            return "Tremor Secundário Ancestral";
        case "Русский":
            return "Повторный толчок Древних";
        case "한국어":
            return "고대의 여진";
        case "简体中文":
            return "上古余震";
        default:
            return "Ancient Aftershock";
        }
    }

    private static string ConquerorsBanner_SpellName()
    {
        // spell=324143
        switch (Language)
        {
        case "English":
            return "Conqueror's Banner";
        case "Deutsch":
            return "Banner des Eroberers";
        case "Español":
            return "Estandarte de conquistador";
        case "Français":
            return "Bannière du conquérant";
        case "Italiano":
            return "Stendardo del Conquistatore";
        case "Português Brasileiro":
            return "Estandarte do Conquistador";
        case "Русский":
            return "Знамя завоевателя";
        case "한국어":
            return "정복자의 깃발";
        case "简体中文":
            return "征服者战旗";
        default:
            return "Conqueror's Banner";
        }
    }

    private static string Bloodlust_SpellName()
    {
        // spell=2825
        switch (Language)
        {
        case "English":
            return "Bloodlust";
        case "Deutsch":
            return "Kampfrausch";
        case "Español":
            return "Ansia de sangre";
        case "Français":
            return "Furie sanguinaire";
        case "Italiano":
            return "Brama di Sangue";
        case "Português Brasileiro":
            return "Sede de Sangue";
        case "Русский":
            return "Жажда крови";
        case "한국어":
            return "피의 욕망";
        case "简体中文":
            return "嗜血";
        default:
            return "Bloodlust";
        }
    }

    private static string TimeWarp_SpellName()
    {
        // spell=80353
        switch (Language)
        {
        case "English":
            return "Time Warp";
        case "Deutsch":
            return "Zeitkrümmung";
        case "Español":
            return "Distorsión temporal";
        case "Français":
            return "Distorsion temporelle";
        case "Italiano":
            return "Distorsione Temporale";
        case "Português Brasileiro":
            return "Distorção Temporal";
        case "Русский":
            return "Искажение времени";
        case "한국어":
            return "시간 왜곡";
        case "简体中文":
            return "时间扭曲";
        default:
            return "Time Warp";
        }
    }

    private static string AncientHysteria_SpellName()
    {
        // spell=90355
        switch (Language)
        {
        case "English":
            return "Ancient Hysteria";
        case "Deutsch":
            return "Uralte Hysterie";
        case "Español":
            return "Histeria ancestral";
        case "Français":
            return "Hystérie ancienne";
        case "Italiano":
            return "Isteria degli Antichi";
        case "Português Brasileiro":
            return "Histeria Ancestral";
        case "Русский":
            return "Древняя истерия";
        case "한국어":
            return "고대의 격분";
        case "简体中文":
            return "远古狂乱";
        default:
            return "Ancient Hysteria";
        }
    }

    private static string Netherwinds_SpellName()
    {
        // spell=160452
        switch (Language)
        {
        case "English":
            return "Netherwinds";
        case "Deutsch":
            return "Netherwinde";
        case "Español":
            return "Vientos abisales";
        case "Français":
            return "Vents du Néant";
        case "Italiano":
            return "Venti Fatui";
        case "Português Brasileiro":
            return "Ventos Etéreos";
        case "Русский":
            return "Ветер Пустоты";
        case "한국어":
            return "황천바람";
        case "简体中文":
            return "虚空之风";
        default:
            return "Netherwinds";
        }
    }

    private static string DrumsofRage_SpellName()
    {
        // item=102351
        switch (Language)
        {
        case "English":
            return "Drums of Rage";
        case "Deutsch":
            return "Trommeln des Zorns";
        case "Español":
            return "Tambores de ira";
        case "Français":
            return "Tambours de rage";
        case "Italiano":
            return "Tamburi della Rabbia";
        case "Português Brasileiro":
            return "Tambores da Raiva";
        case "Русский":
            return "Барабаны ярости";
        case "한국어":
            return "분노의 북";
        case "简体中文":
            return "暴怒之鼓";
        default:
            return "Drums of Rage";
        }
    }

    private static string Victorious_SpellName()
    {
        // spell=32216
        switch (Language)
        {
        case "English":
            return "Victorious";
        case "Deutsch":
            return "Siegreich";
        case "Español":
            return "Victorioso";
        case "Français":
            return "Victorieux";
        case "Italiano":
            return "Vittoria in Pugno";
        case "Português Brasileiro":
            return "Vitorioso";
        case "Русский":
            return "Победа";
        case "한국어":
            return "승리";
        case "简体中文":
            return "胜利";
        default:
            return "Victorious";
        }
    }

    private static string RevengeI_SpellName()
    {
        // spell=5302
        switch (Language)
        {
        case "English":
            return "Revenge!";
        case "Deutsch":
            return "Rache!";
        case "Español":
            return "¡Revancha!";
        case "Français":
            return "Revanche !";
        case "Italiano":
            return "Rivincita!";
        case "Português Brasileiro":
            return "Revanche!";
        case "Русский":
            return "Реванш";
        case "한국어":
            return "복수!";
        case "简体中文":
            return "复仇！";
        default:
            return "Revenge!";
        }
    }

    private static string PhialofSerenity_SpellName()
    {
        // item=177278
        switch (Language)
        {
        case "English":
            return "Phial of Serenity";
        case "Deutsch":
            return "Phiole des Gleichmuts";
        case "Español":
            return "Ampolla de serenidad";
        case "Français":
            return "Flasque de sérénité";
        case "Italiano":
            return "Fiala della Serenità";
        case "Português Brasileiro":
            return "Frasco de Serenidade";
        case "Русский":
            return "Флакон безмятежности";
        case "한국어":
            return "평온의 약병";
        case "简体中文":
            return "静谧之瓶";
        default:
            return "Phial of Serenity";
        }
    }

    private static string ChallengingShout_SpellName()
    {
        // spell=1161
        switch (Language)
        {
        case "English":
            return "Challenging Shout";
        case "Deutsch":
            return "Herausforderungsruf";
        case "Español":
            return "Grito desafiante";
        case "Français":
            return "Cri de défi";
        case "Italiano":
            return "Urlo di Sfida";
        case "Português Brasileiro":
            return "Brado Desafiador";
        case "Русский":
            return "Вызывающий крик";
        case "한국어":
            return "도전의 외침";
        case "简体中文":
            return "挑战怒吼";
        default:
            return "Challenging Shout";
        }
    }

    private static string SpellReflection_SpellName()
    {
        // spell=23920
        switch (Language)
        {
        case "English":
            return "Spell Reflection";
        case "Deutsch":
            return "Zauberreflexion";
        case "Español":
            return "Reflejo de hechizos";
        case "Français":
            return "Renvoi de sort";
        case "Italiano":
            return "Rifletti Incantesimo";
        case "Português Brasileiro":
            return "Reflexão de Feitiço";
        case "Русский":
            return "Отражение заклинаний";
        case "한국어":
            return "주문 반사";
        case "简体中文":
            return "法术反射";
        default:
            return "Spell Reflection";
        }
    }

    private static string DragonRoar_SpellName()
    {
        // spell=274775
        switch (Language)
        {
        case "English":
            return "Dragon Roar";
        case "Deutsch":
            return "Drachengebrüll";
        case "Español":
            return "Rugido de dragón";
        case "Français":
            return "Rugissement de dragon";
        case "Italiano":
            return "Ruggito del Drago";
        case "Português Brasileiro":
            return "Rugido do Dragão";
        case "Русский":
            return "Рев дракона";
        case "한국어":
            return "용의 포효";
        case "简体中文":
            return "巨龙怒吼";
        default:
            return "Dragon Roar";
        }
    }
    #endregion

    private static bool CanUseTrinket(string TrinketName, string TopTrinket, string BotTrinket)
    {
        if ((Aimsharp.CanUseTrinket(0) && TopTrinket == TrinketName) || (Aimsharp.CanUseTrinket(1) && BotTrinket == TrinketName))
        {
            return true;
        }
        return false;
    }

    private static void CastTrinketByName(string TrinketName, string TopTrinket, string BotTrinket)
    {
        if (TopTrinket == TrinketName)
        {
            Aimsharp.Cast("MacroTopTrinket", true);
        }
        if (BotTrinket == TrinketName)
        {
            Aimsharp.Cast("MacroBotTrinket", true);
        }
    }

    private static string Language = "English";
    public override void LoadSettings()
    {
        Settings.Add(new Setting("Game Client Language", new List<string>()
            {
                "English", 
                "Deutsch", 
                "Español", 
                "Français", 
                "Italiano", 
                "Português Brasileiro", 
                "Русский", 
                "한국어", 
                "简体中文"
            }, "English"));
        List<string> Trinkets = new List<string>(new string[] 
            {
                "Blood-Spattered Scale",
                "Dreadfire Vessel", 
                "Generic", 
                "Macabre Sheet Music", 
                "Sanguine Vintage", 
                "Skulker's Wing", 
                "Slimy Consumptive Organ", 
                "None"                
            });
        Settings.Add(new Setting("Top Trinket", Trinkets, "None"));
        Settings.Add(new Setting("Bot Trinket", Trinkets, "None"));
        List<string> Race = new List<string>(new string[]
            {
                "Bloodelf", 
                "Dark Iron Dwarf", 
                "Lightforged Draenei", 
                "Mag'har Orc", 
                "Orc", 
                "Tauren", 
                "Troll", 
                "Vulpera", 
                "None"});
        Settings.Add(new Setting("Racial Power", Race, "None"));
        Settings.Add(new Setting("Use item with Heroism: Case Sens", "Potion of Spectral Strength"));
        Settings.Add(new Setting("Mitigation"));
        Settings.Add(new Setting("Use only free Revenge", false));
        Settings.Add(new Setting("Use Ignore Pain for survival @ HP%", 0, 100, 75));  
        Settings.Add(new Setting("Auto Victory Rush @ HP%", 0, 100, 70)); 
        Settings.Add(new Setting("Auto Shout @ HP%", 0, 100, 33));  
        Settings.Add(new Setting("Auto Last Stand @ HP%", 0, 100, 26));       
        Settings.Add(new Setting("Auto Shield Wall @ HP%", 0, 100, 24));          
        Settings.Add(new Setting("Auto Healthstone @ HP%", 0, 100, 25));    
        Settings.Add(new Setting("Auto Kyrian Phial @ HP%", 0, 100, 35));       
        Settings.Add(new Setting("Auto Intervene @ Focus HP%", 0, 100, 40)); 
        List<string> Legendary = new List<string>(new string[] 
            {
                "The Wall",
                "Thunderlord",
                "Reprisal",
                "None"
            });
        Settings.Add(new Setting("Legendary Effect", Legendary, "None"));
        Settings.Add(new Setting("First 5 Letters of the Addon:", "xxxxx"));
        Settings.Add(new Setting(""));
    }
    
    string TopTrinket;
    string BotTrinket;
    string RacialPower;
    string FiveLetters;
    string usableitems;
    string LegendaryEffect;

    public override void Initialize()
    {
        // Aimsharp.DebugMode();

        Aimsharp.PrintMessage("Kaneto's Protection Warrior 9.0.2", Color.Yellow);
        Aimsharp.PrintMessage("--Raid Talents: 3221211, M+ Talents: 3221233", Color.Yellow);
        Aimsharp.PrintMessage("These macros can be used for manual control:", Color.Blue);
        Aimsharp.PrintMessage("/xxxxx Potions --Toggles using buff potions on/off.", Color.Blue);
        Aimsharp.PrintMessage("/xxxxx SaveCooldowns --Toggles the use of big cooldowns on/off.", Color.Blue);
        Aimsharp.PrintMessage("/xxxxx AutoCharge --Toggles on Automatic Charge.", Color.Blue);
        Aimsharp.PrintMessage("/xxxxx Interrupts --Toggles off Interrupt Usage.", Color.Blue);
        Aimsharp.PrintMessage("/xxxxx ThreatControl --Toggles on/off Auto Taunting if you don't have Aggro on specific target.", Color.Blue);
        Aimsharp.PrintMessage("/xxxxx InterveneOn --Toggles on/off Auto Intervene at Focus Health % and when Reprisal is equipped.", Color.Blue);
        Aimsharp.PrintMessage("/xxxxx AOE --Toggles AOE mode on/off.", Color.Orange);
        Aimsharp.PrintMessage("/xxxxx RaidWarning --Toggles Raidwarnings for Phases on/off.", Color.Orange);
        Aimsharp.PrintMessage("/xxxxx StormBolt --Queues Storm Bolt up to be used on the next GCD.", Color.Red);
        Aimsharp.PrintMessage("/xxxxx RallyingCry --Queues Rallying Cry up to be used on the next GCD.", Color.Red);
        Aimsharp.PrintMessage("/xxxxx IntimidatingShout --Queues Intimidating Shout up to be used on the next GCD.", Color.Red);
        Aimsharp.PrintMessage("/xxxxx ShockWave -- Queues Shockwave to be used on the next GCD.", Color.Red); 
        Aimsharp.PrintMessage("/xxxxx ShatteringThrow --Queues Shattering Throw up to be used on the next GCD.", Color.Red);
        Aimsharp.PrintMessage("--Replace xxxxx with first 5 letters of your addon, lowercase.", Color.Yellow);

        Aimsharp.Latency = 50;
        Aimsharp.QuickDelay = 125;
        Aimsharp.SlowDelay = 250;

        TopTrinket = GetDropDown("Top Trinket");
        BotTrinket = GetDropDown("Bot Trinket");
        RacialPower = GetDropDown("Racial Power");
        FiveLetters = GetString("First 5 Letters of the Addon:");            
        usableitems = GetString("Use item with Heroism: Case Sens");

        //Language
        Language = GetDropDown("Game Client Language");

        //Legendary
        LegendaryEffect = GetDropDown("Legendary Effect");

        //Racial Powers
        if (RacialPower == "Orc")
            Spellbook.Add(BloodFury_SpellName());
        if (RacialPower == "Troll")
            Spellbook.Add(Berserking_SpellName());
        if (RacialPower == "Dark Iron Dwarf")
            Spellbook.Add(Fireblood_SpellName());
        if (RacialPower == "Mag'har Orc")
            Spellbook.Add(AncestralCall_SpellName());
        if (RacialPower == "Lightforged Draenei")
            Spellbook.Add(LightsJudgment_SpellName());
        if (RacialPower == "Bloodelf")
            Spellbook.Add(ArcaneTorrent_SpellName());
        if (RacialPower == "Tauren") 
            Spellbook.Add(WarStomp_SpellName());
        if (RacialPower == "Vulpera") 
            Spellbook.Add(BagofTricks_SpellName());

        //General Abilities
        Spellbook.Add(Avatar_SpellName());
        Spellbook.Add(BattleShout_SpellName());
        Spellbook.Add(Charge_SpellName());
        Spellbook.Add(DemoralizingShout_SpellName());
        Spellbook.Add(Devastate_SpellName());
        Spellbook.Add(Execute_SpellName());
        Spellbook.Add(IgnorePain_SpellName());
        Spellbook.Add(Intervene_SpellName());           
        Spellbook.Add(IntimidatingShout_SpellName());
        Spellbook.Add(LastStand_SpellName());
        Spellbook.Add(Pummel_SpellName());
        Spellbook.Add(RallyingCry_SpellName());
        Spellbook.Add(Ravager_SpellName());
        Spellbook.Add(Revenge_SpellName());
        Spellbook.Add(ShatteringThrow_SpellName());
        Spellbook.Add(ShieldBlock_SpellName());
        Spellbook.Add(ShieldSlam_SpellName());
        Spellbook.Add(ShieldWall_SpellName());
        Spellbook.Add(Shockwave_SpellName());
        Spellbook.Add(SpellReflection_SpellName());
        Spellbook.Add(StormBolt_SpellName());
        Spellbook.Add(ThunderClap_SpellName());
        Spellbook.Add(VictoryRush_SpellName());

        //Covenant Abilities
        Spellbook.Add(AncientAftershock_SpellName());
        Spellbook.Add(ConquerorsBanner_SpellName());
        Spellbook.Add(SpearofBastion_SpellName());

        //Heroism Buffs
        Buffs.Add(AncientHysteria_SpellName());
        Buffs.Add(Bloodlust_SpellName());
        Buffs.Add(DrumsofRage_SpellName());
        Buffs.Add(Heroism_SpellName());
        Buffs.Add(Netherwinds_SpellName());
        Buffs.Add(SpellReflection_SpellName());
        Buffs.Add(TimeWarp_SpellName());

        //General Buffs
        Buffs.Add(Avatar_SpellName());
        Buffs.Add(BattleShout_SpellName());
        Buffs.Add(IgnorePain_SpellName());
        Buffs.Add(RevengeI_SpellName());
        Buffs.Add(ShieldBlock_SpellName());
        Buffs.Add(Victorious_SpellName());

        //Items used
        Items.Add(usableitems);
        Items.Add(Healthstone_SpellName());
        Items.Add(PhialofSerenity_SpellName());

        //Special Macros
        Macros.Add("MacroItemUse", "/use " +usableitems);
        Macros.Add("MacroTopTrinket", "/use 13");
        Macros.Add("MacroBotTrinket", "/use 14");
        Macros.Add("MacroPotion", "/use " + PhialofSerenity_SpellName());
        Macros.Add("MacroStormBoltOff", "/"+FiveLetters+" StormBolt");
        Macros.Add("MacroIntimidatingShoutOff", "/"+FiveLetters+" IntimidatingShout");
        Macros.Add("MacroRallyingCryOff", "/"+FiveLetters+" RallyingCry");
        Macros.Add("MacroShockWaveOff", "/"+FiveLetters+" ShockWave");    
        Macros.Add("MacroShatteringThrowOff", "/" + FiveLetters + " ShatteringThrow");
        Macros.Add("MacroBastion","/cast [@player] " + SpearofBastion_SpellName());
        Macros.Add("MacroRavageSelf", "/cast [@player] " + Ravager_SpellName());
        Macros.Add("MacroInterveneFocus", "/cast [target=focus] " + Intervene_SpellName());

        //Macros for Raid Warnings
        Macros.Add("RaidBloodlust", "/rw !! BL / Hero / BT !!");

        //Sire Denathrius
        Macros.Add("RaidDenathriusPhase1", "/rw Stack on your groups! Big AOE on the Adds! Get the Group healthy for Blood Price! Move the circles out of the group!");
        Macros.Add("RaidDenathriusPhase2", "/rw Big Dmg on Adds! Red glowing adds receive more dmg! Don't stand in front of Denathrius! Move Impale out of the group! Move through the mirror when Denathrius pulls you in!");
        Macros.Add("RaidDenathriusIntermission", "/rw Everyone with more than 3 stacks probably dies. Run to the middle and damage Denathrius!");
        Macros.Add("RaidDenathriusPhase3", "/rw Move the Circles out of the Groups! Watch out for the Knockback! Run to the other side of Hand of Destructions! If Adds are alive: Kill them!");

        //Shriekwing
        Macros.Add("RaidShriekwingPhase1", "/rw Dodge the white circles! Dodge Blind Swipe (Melee)! Stand out of line of sight when he shrieks! Get Echolocation to the side of the room!");
        Macros.Add("RaidShriekwingPhase2", "/rw Attack until he knocks you away! Then don't go near him! Dodge the white circles and stand out of line of sight when he shrieks!");

        //Huntsman Altimor
        Macros.Add("RaidHuntsmanPhase1", "/rw ");
        Macros.Add("RaidHuntsmanPhase2", "/rw ");
        Macros.Add("RaidHuntsmanPhase3", "/rw ");

        //Hungering Destroyer
        Macros.Add("RaidDestroyerPhase1", "/rw ");
        Macros.Add("RaidDestroyerPhase2", "/rw ");

        //Lady Darkvein
        Macros.Add("RaidDarkveinPhase1", "/rw ");
        Macros.Add("RaidDarkveinPhase2", "/rw ");

        //Sun King's Salvation
        Macros.Add("RaidSunKingPhase1", "/rw ");
        Macros.Add("RaidSunKingPhase2", "/rw ");

        //Artificier Xymox
        Macros.Add("RaidXymoxPhase1", "/rw ");
        Macros.Add("RaidXymoxPhase2", "/rw ");
        Macros.Add("RaidXymoxPhase3", "/rw ");

        //Council of Blood
        Macros.Add("RaidCouncilPhase1", "/rw ");
        Macros.Add("RaidCouncilPhase2", "/rw ");
        Macros.Add("RaidCouncilPhase3", "/rw ");
        Macros.Add("RaidCouncilDance", "/rw !! Dance !! Follow the instructions and move one square left, right, forwards, backwards.");

        //Sludgefist
        Macros.Add("RaidSludgefistPhase1", "/rw ");
        Macros.Add("RaidSludgefistPhase2", "/rw ");

        //Stone Legion Generals
        Macros.Add("RaidGeneralsPhase1", "/rw ");
        Macros.Add("RaidGeneralsPhase2", "/rw ");
        Macros.Add("RaidGeneralsIntermission", "/rw ");

        //Custom Commands
        CustomCommands.Add("Potions");
        CustomCommands.Add("SaveCooldowns");
        CustomCommands.Add("AOE");
        CustomCommands.Add("StormBolt");
        CustomCommands.Add("RallyingCry");
        CustomCommands.Add("IntimidatingShout");
        CustomCommands.Add("ShockWave");
        CustomCommands.Add("AutoCharge");
        CustomCommands.Add("Interrupts");
        CustomCommands.Add("ThreatControl");          
        CustomCommands.Add("ShatteringThrow");
        CustomCommands.Add("RaidWarning");
        CustomCommands.Add("InterveneOn");

        //Custom Function
        CustomFunctions.Add("IsTanking", "if (UnitDetailedThreatSituation(\"player\", \"target\"))\nthen\nreturn 1;\nend\nreturn 0;");
        //CustomFunctions.Add("GetLatency", "local ,,_,lagWorld = GetNetStats();return lagWorld;");
        //CustomFunctions.Add("GetSpellQueueWindow", "local sqw = GetCVar(\"SpellQueueWindow\");return tonumber(sqw);");
    }


    // optional override for the CombatTick which executes while in combat
    public override bool CombatTick() 
    {
        bool UseOnlyFreeRevenge = GetCheckBox("Use only free Revenge");

        bool Fighting = Aimsharp.Range("target") <= 8 && Aimsharp.TargetIsEnemy();
        bool Moving = Aimsharp.PlayerIsMoving();
        float Haste = Aimsharp.Haste() / 100f;
        int Time = Aimsharp.CombatTime();
        int Range = Aimsharp.Range("target");
        int TargetHealth = Aimsharp.Health("target");
        string LastCast = Aimsharp.LastCast();
        bool IsChanneling = Aimsharp.IsChanneling("player");

        bool NoCooldowns = Aimsharp.IsCustomCodeOn("SaveCooldowns");
        bool AOE = Aimsharp.IsCustomCodeOn("AOE");

        int EnemiesInMelee = Aimsharp.EnemiesInMelee();
        int EnemiesNearTarget = Aimsharp.EnemiesNearTarget();
        int GCDMAX = (int) (1500f / (Haste + 1f));
        int GCD = Aimsharp.GCD();
        int Latency = Aimsharp.Latency;
        int PlayerHealth = Aimsharp.Health("player");
        int GroupSize = Aimsharp.GroupSize();

        int FocusHealth = Aimsharp.Health("focus");
        bool NoFocus = false;
        if (FocusHealth == 0) {NoFocus=true;}
        
        bool HasLust = Aimsharp.HasBuff(Bloodlust_SpellName(), "player", false) ||
                        Aimsharp.HasBuff(Heroism_SpellName(), "player", false) ||
                        Aimsharp.HasBuff(TimeWarp_SpellName(), "player", false) ||
                        Aimsharp.HasBuff(AncientHysteria_SpellName(), "player", false) ||
                        Aimsharp.HasBuff(Netherwinds_SpellName(), "player", false) ||
                        Aimsharp.HasBuff(DrumsofRage_SpellName(), "player", false);

        //Target ID and Boss IDs
        int TargetID = Aimsharp.UnitID("target");
        int TargetCastingID = Aimsharp.CastingID("target");
        int BossID1 = Aimsharp.UnitID("boss1");
        int BossID2 = Aimsharp.UnitID("boss2");
        int BossID3 = Aimsharp.UnitID("boss3");
        int BossID4 = Aimsharp.UnitID("boss4");
        int BossCastingID1 = Aimsharp.CastingID("boss1");
        int BossCastingID2 = Aimsharp.CastingID("boss2");
        int BossCastingID3 = Aimsharp.CastingID("boss3");
        int BossCastingID4 = Aimsharp.CastingID("boss4");
        int BossHealth1 = Aimsharp.Health("boss1");
        int BossHealth2 = Aimsharp.Health("boss2");
        int BossHealth3 = Aimsharp.Health("boss3");
        int BossHealth4 = Aimsharp.Health("boss4");

        //Commands
        bool UsePotion = Aimsharp.IsCustomCodeOn("Potions");               
        bool StormBolt = Aimsharp.IsCustomCodeOn("StormBolt");
        bool RallyingCry = Aimsharp.IsCustomCodeOn("RallyingCry");
        bool IntimidatingShout = Aimsharp.IsCustomCodeOn("IntimidatingShout");
        bool ShockWave = Aimsharp.IsCustomCodeOn("ShockWave");
        bool AutomaticCharge = Aimsharp.IsCustomCodeOn("AutoCharge");
        bool InterruptsOff = Aimsharp.IsCustomCodeOn("Interrupts");
        bool ThreatControl = Aimsharp.IsCustomCodeOn("ThreatControl");
        int IsTanking = Aimsharp.CustomFunction("IsTanking");
        bool ShatteringThrow = Aimsharp.IsCustomCodeOn("ShatteringThrow");
        bool RaidWarning = Aimsharp.IsCustomCodeOn("RaidWarning");
        bool InterveneOn = Aimsharp.IsCustomCodeOn("InterveneOn");

        if (!AOE) 
        {
            EnemiesNearTarget = 1;
            EnemiesInMelee = EnemiesInMelee > 0 ? 1 : 0;
        }
        
        //Talent
        bool TalentStormbolt = Aimsharp.Talent(2, 3);
        bool TalentBoomingVoice = Aimsharp.Talent(3, 2);
        bool TalentUnstoppableForce = Aimsharp.Talent(6, 2);
        bool TalentBolster = Aimsharp.Talent(7, 3);

        bool IgnorePainUP = Aimsharp.HasBuff(IgnorePain_SpellName());

        int Rage = Aimsharp.Power("player");
        int MaxRage = Aimsharp.PlayerMaxPower();
        int RageDefecit = MaxRage - Rage;

        int BuffAvatarRemains = Aimsharp.BuffRemaining(Avatar_SpellName()) - GCD;
        bool BuffAvatarUp = BuffAvatarRemains > 0;
        int BuffLastStandRemains = Aimsharp.BuffRemaining(LastStand_SpellName()) - GCD;
        bool BuffLastStandUp = BuffLastStandRemains > 0;
        int BuffShieldBlockRemains = Aimsharp.BuffRemaining(ShieldBlock_SpellName()) - GCD;
        bool BuffShieldBlockUp = BuffShieldBlockRemains > 0;
        int ShieldBlockCharges = Aimsharp.SpellCharges(ShieldBlock_SpellName());
        bool BuffRevengeUp = Aimsharp.HasBuff(RevengeI_SpellName());
        int BuffSpellReflectionRemains = Aimsharp.BuffRemaining(SpellReflection_SpellName()) - GCD;
        bool BuffSpellReflectionUp = BuffShieldBlockRemains > 0;
        
        int CDAvatarRemains = Aimsharp.SpellCooldown(Avatar_SpellName()) - GCD;
        bool CDAvatarReady = CDAvatarRemains <= 10;
        int CDShieldSlamRemains = Aimsharp.SpellCooldown(ShieldSlam_SpellName()) - GCD;
        bool CDShieldSlamReady = CDShieldSlamRemains <= 10;
        int CDDemoralizingShoutRemains = Aimsharp.SpellCooldown(DemoralizingShout_SpellName()) - GCD;
        bool CDDemoralizingShoutReady = CDDemoralizingShoutRemains <= 10;

        int CDStormBoltRemains = Aimsharp.SpellCooldown(StormBolt_SpellName());
        bool CDStormBoltUp = CDStormBoltRemains > GCD;
        int CDIntimidatingShoutRemains = Aimsharp.SpellCooldown(IntimidatingShout_SpellName());
        int CDRallyingCryRemains = Aimsharp.SpellCooldown(RallyingCry_SpellName());
        int CDShockwaveRemains = Aimsharp.SpellCooldown(Shockwave_SpellName());
        int CDShatteringThrowRemains = Aimsharp.SpellCooldown(ShatteringThrow_SpellName()) - GCD;

        //Covenant CD
        int CDSpearRemains = Aimsharp.SpellCooldown(SpearofBastion_SpellName()) - GCD;
        bool CDSpearReady = CDSpearRemains <= 10;           
        int CDAftershockRemains = Aimsharp.SpellCooldown(AncientAftershock_SpellName()) - GCD;
        bool CDAftershockReady = CDAftershockRemains <= 10;
        
        //Legendaries
        bool runeforge_the_wall_equipped = LegendaryEffect == "The Wall";
        bool runeforge_thunderlord_equipped = LegendaryEffect == "Thunderlord";
        bool runeforge_reprisal_equipped = LegendaryEffect == "Reprisal";

        //Interrupt Setup
        bool IsInterruptable = Aimsharp.IsInterruptable("target");
        int CastingRemaining = Aimsharp.CastingRemaining("target");
        int CastingElapsed = Aimsharp.CastingElapsed("target");
        bool IsChannelingTar = Aimsharp.IsChanneling("target");
        int KickValue = 300;
        int KickChannelsAfter = 500;

        //GetCovenant
        int CovenantID = Aimsharp.CovenantID();
        bool CovenantKyrian = CovenantID == 1;
        bool CovenantVenthyr = CovenantID == 2;
        bool CovenantNightFae = CovenantID == 3;
        bool CovenantNecrolord = CovenantID == 4;

        //DPS Calculation
        int TargetMaxHP = Aimsharp.TargetMaxHP();
        int TargetCurrentHP = Aimsharp.TargetCurrentHP();
        var TargetDamageTakenPerSecond = (TargetMaxHP - TargetCurrentHP) / (Math.Floor((double)Time/1000));
        int TargetTimeToDie = (int)Math.Ceiling(TargetCurrentHP / TargetDamageTakenPerSecond);

        //Latency
        //int lagWorld = Aimsharp.CustomFunction("GetLatency");
        //int sqw = Aimsharp.CustomFunction("GetSpellQueueWindow");
        //Aimsharp.PrintMessage("Der LAG ist momentan: " + lagWorld, Color.Yellow);
        //Aimsharp.PrintMessage("Das sqw ist momentan: " + sqw, Color.Yellow);

        if (IsChanneling)
            return false;

        
        if (Fighting) 
        {
            #region RaidUtility
            // Sire Denathrius
            if (BossID1 == 168938 || BossID2 == 168938)
            {
                //Raid Warnings
                if (RaidWarning)
                {
                    if (BossHealth1 == 99)
                    {
                        Aimsharp.Cast("RaidDenathriusPhase1", true);
                        return true;
                    }

                    if (BossHealth1 == 71)
                    {
                        Aimsharp.Cast("RaidDenathriusIntermission", true);
                        return true;
                    }

                    if (BossHealth1 == 69)
                    {
                        Aimsharp.Cast("RaidDenathriusPhase2", true);
                        return true;
                    }

                    if (BossHealth1 == 40)
                    {
                        Aimsharp.Cast("RaidDenathriusPhase3", true);
                        return true;
                    }
                }

                //Spell Reflection Blood Price
                if ((BossCastingID1 == 326851 || BossCastingID2 == 326851) && Aimsharp.CanCast(SpellReflection_SpellName(), "player"))
                {
                    Aimsharp.Cast(SpellReflection_SpellName());
                    return true;
                }
            }

            //Shriekwing

            if (BossID1 == 164406)
            {
                //Raid Warnings
                if (RaidWarning)
                {
                    if (BossHealth1 == 99)
                    {
                        Aimsharp.Cast("RaidShriekwingPhase1", true);
                        return true;
                    }

                    if (BossCastingID1 == 328921)
                    {
                        Aimsharp.Cast("RaidShriekwingPhase2", true);
                        return true;
                    }                   
                }

                if (BossCastingID1 == 328857 && BuffShieldBlockUp && Aimsharp.CanCast(ShieldBlock_SpellName(), "player"))
                {
                    Aimsharp.Cast(ShieldBlock_SpellName());
                    return true;
                }

            }

            //Huntsman Altimor
            if (BossID1 == 168938 )
            {
                //Raid Warnings


                

            }

            //Hungering Destroyer
            if (BossID1 == 168938 )
            {
                //Raid Warnings


                

            }

            //Lady Darkvein
            if (BossID1 == 168938 )
            {
                //Raid Warnings


                

            }

            //Sun King's Salvation
            if (BossID1 == 168938 )
            {
                //Raid Warnings


                

            }

            //Artificier Xymox
            if (BossID1 == 168938 )
            {
                //Raid Warnings


                

            }

            //Council of Blood
            if (BossID1 == 168938 )
            {
                //Raid Warnings


                

            }

            //Sludgefist
            if (BossID1 == 168938 )
            {
                //Raid Warnings


                

            }

            //Stone Legion Generals
            if (BossID1 == 168938 )
            {
                //Raid Warnings


                

            }
            }
            #endregion

            #region Utility
            // QUEUED STORMBOLT
            if (CDStormBoltRemains > 5000 && StormBolt) 
            {
                Aimsharp.Cast("MacroStormBoltOff");
                return true;
            }

            if (StormBolt && Aimsharp.CanCast(StormBolt_SpellName())) 
            {
                Aimsharp.PrintMessage("Queued Storm Bolt");
                Aimsharp.Cast(StormBolt_SpellName());
                return true;
            }

            // QUEUED SHATTERING THROW
            if (CDShatteringThrowRemains > 5000 && ShatteringThrow) 
            {
                Aimsharp.Cast("MacroShatteringThrowOff", true);
                return true;
            }
            if (ShatteringThrow && Aimsharp.CanCast(ShatteringThrow_SpellName(), "player")) 
            {
                Aimsharp.PrintMessage("Queued Shattering Throw");
                Aimsharp.Cast(ShatteringThrow_SpellName());
                return true;
            }

            // QUEUED INTIMIDATING SHOUT
            if (CDIntimidatingShoutRemains > 5000 && IntimidatingShout) 
            {
                Aimsharp.Cast("MacroIntimidatingShoutOff");
                return true;
            }

            if (IntimidatingShout && Aimsharp.CanCast(IntimidatingShout_SpellName())) 
            {
                Aimsharp.PrintMessage("Queued Intimidating Shout");
                Aimsharp.Cast(IntimidatingShout_SpellName());
                return true;
            }

            // QUEUED RALLYING CRY
            if (CDRallyingCryRemains > 5000 && RallyingCry) 
            {
                Aimsharp.Cast("MacroRallyingCryOff");
                return true;
            }

            if (RallyingCry && Aimsharp.CanCast(RallyingCry_SpellName(), "player")) 
            {
                Aimsharp.PrintMessage("Queued Rallying Cry");
                Aimsharp.Cast(RallyingCry_SpellName());
                return true;
            }

            // QUEUED Shockwave
            if (CDShockwaveRemains > 5000 && ShockWave) 
            {
                Aimsharp.Cast("MacroShockWaveOff");
                return true;
            }

            if (ShockWave && Aimsharp.CanCast(Shockwave_SpellName(), "player")) 
            {
                Aimsharp.PrintMessage("Queued Shockwave");
                Aimsharp.Cast(Shockwave_SpellName());
                return true;
            }

            // Auto Victory Rush
            if (Aimsharp.CanCast(VictoryRush_SpellName())) 
            {
                if (PlayerHealth <= GetSlider("Auto Victory Rush @ HP%")) 
                {
                    Aimsharp.Cast(VictoryRush_SpellName());
                    return true;
                }
            }
            
            //Auto Last Stand
            if (Aimsharp.CanCast(LastStand_SpellName(), "player")) 
            {
                if (PlayerHealth <= GetSlider("Auto Last Stand @ HP%")) 
                {
                    Aimsharp.Cast(LastStand_SpellName());
                    return true;
                }
            }
            
            //Auto Healthstone
            if (Aimsharp.CanUseItem(Healthstone_SpellName())) 
            {
                if (PlayerHealth <= GetSlider("Auto Healthstone @ HP%")) 
                {
                    Aimsharp.Cast(Healthstone_SpellName());
                    return true;
                }
            }
            
            //Auto Rallying Cry
            if (Aimsharp.CanCast(RallyingCry_SpellName(), "player")) 
            {
                if (PlayerHealth <= GetSlider("Auto Shout @ HP%")) 
                {
                    Aimsharp.Cast(RallyingCry_SpellName());
                    return true;
                }
            }
            
            //Auto Shield Wall
            if (Aimsharp.CanCast(ShieldWall_SpellName(), "player")) 
            {
                if (PlayerHealth <= GetSlider("Auto Shield Wall @ HP%")) 
                {
                    Aimsharp.Cast(ShieldWall_SpellName());
                    return true;
                }
            }

            //Automatic Charge
            if (AutomaticCharge && Aimsharp.CanCast(Charge_SpellName(), "player"))
            {
                if (Range >= 8 && Range <= 30)
                {
                    Aimsharp.Cast(Charge_SpellName(), true);
                    return true;
                }
            }   

            //Auto Intervene Focus
            if (!NoFocus && InterveneOn && FocusHealth <= GetSlider("Auto Intervene @ Focus HP%") && Aimsharp.CanCast(Intervene_SpellName(), "player"))
            {
                Aimsharp.Cast("MacroInterveneFocus", true);
                return true;
            }

            //Auto Taunt if Threat Loss
            if (ThreatControl)
            {
                if (IsTanking == 0 && Aimsharp.CanCast(Taunt_SpellName(),"player"))
                {
                    Aimsharp.Cast(Taunt_SpellName());
                    return true;
                }

                if (IsTanking == 0 && Range <= 8 && !Aimsharp.CanCast(Taunt_SpellName(),"player") && Aimsharp.CanCast(ChallengingShout_SpellName(),"player"))
                {
                    Aimsharp.Cast(ChallengingShout_SpellName());
                    return true;
                }

            }

            #endregion

            #region Interrupts
            // Interrupts
            
            if (!InterruptsOff && !BuffSpellReflectionUp)
            {
                if (Aimsharp.CanCast(Pummel_SpellName()))
                {
                    if (IsInterruptable && !IsChannelingTar && CastingRemaining < KickValue && CastingElapsed > 500)
                    {
                        Aimsharp.Cast(Pummel_SpellName(), true);
                        return true;
                    }
                }
                if (Aimsharp.CanCast(Pummel_SpellName()))
                {
                    if (IsInterruptable && IsChannelingTar && CastingElapsed > KickChannelsAfter)
                    {
                        Aimsharp.Cast(Pummel_SpellName(), true);
                        return true;
                    }
                }

                //Stormbolt to interrupt Casts
                if (TalentStormbolt)
                {
                    if (!NoCooldowns && !Aimsharp.CanCast(Pummel_SpellName())&& Aimsharp.CanCast(StormBolt_SpellName()) && CastingRemaining < KickValue && (IsChannelingTar || IsInterruptable || !IsInterruptable))
                    {
                        Aimsharp.Cast(StormBolt_SpellName(), true);
                        return true;
                    }
                }           

                //Intimidating Shout if alone
                if (GroupSize == 0 && Aimsharp.CanCast(IntimidatingShout_SpellName()) && CastingRemaining < KickValue && (IsInterruptable || IsChannelingTar))
                {
                    Aimsharp.Cast(IntimidatingShout_SpellName(), true);
                    return true;
                }
            

                //War Stomp if Enemies in Range and Interrupt is down
                if (!Aimsharp.CanCast(Pummel_SpellName(), "player") && !Aimsharp.CanCast(IntimidatingShout_SpellName(), "player") && !Aimsharp.CanCast(StormBolt_SpellName(), "player") && Aimsharp.CanCast(WarStomp_SpellName(), "player"))
                {
                    if (EnemiesInMelee >= 1 && IsInterruptable && !IsChannelingTar && CastingRemaining < 300 && CastingElapsed > 500)
                    {
                        Aimsharp.Cast(WarStomp_SpellName(), true);
                        return true;
                    }

                    if (EnemiesInMelee >= 1 && IsInterruptable && IsChannelingTar && CastingElapsed > 500)
                    {
                        Aimsharp.Cast(WarStomp_SpellName(), true);
                        return true;
                    }
                }
            }     

            //Auto Spell Reflection
            if (!Aimsharp.CanCast(Pummel_SpellName(), "player") && !Aimsharp.CanCast(IntimidatingShout_SpellName(), "player") && !Aimsharp.CanCast(StormBolt_SpellName(), "player") && Aimsharp.CanCast(SpellReflection_SpellName(), "player"))
            {
                if (CastingRemaining < 300)
                {
                    Aimsharp.Cast(SpellReflection_SpellName(), true);
                    return true;
                }
            }

            #endregion
        
            //COOLDOWNS
            if (!NoCooldowns && Fighting)
            {
                if (CanUseTrinket("Blood-Spattered Scale", TopTrinket, BotTrinket) && GroupSize > 3)
                {
                    if (CDAvatarRemains <= GCD || BuffAvatarUp) 
                    {
                        CastTrinketByName("Blood-Spattered Scale", TopTrinket, BotTrinket);
                        return true;
                    }
                }

                if (CanUseTrinket("Dreadfire Vessel", TopTrinket, BotTrinket) && BuffAvatarUp)
                {
                    if (CDAvatarRemains <= GCD || BuffAvatarUp) 
                    {
                        CastTrinketByName("Dreadfire Vessel", TopTrinket, BotTrinket);
                        return true;
                    }
                }

                if (CanUseTrinket("Sanguine Vintage", TopTrinket, BotTrinket))
                {
                    if (CDAvatarRemains <= GCD || BuffAvatarUp) 
                    {
                        CastTrinketByName("Sanguine Vintage", TopTrinket, BotTrinket);
                        return true;
                    }
                }

                if (CanUseTrinket("Macabre Sheet Music", TopTrinket, BotTrinket))
                {
                    if (CDAvatarRemains <= GCD || BuffAvatarUp) 
                    {
                        CastTrinketByName("Macabre Sheet Music", TopTrinket, BotTrinket);
                        return true;
                    }
                }

                if (CanUseTrinket("Skulker's Wing", TopTrinket, BotTrinket) && BuffAvatarUp)
                {
                    if (CDAvatarRemains <= GCD || BuffAvatarUp) 
                    {
                        CastTrinketByName("Skulker's Wing", TopTrinket, BotTrinket);
                        return true;
                    }
                }

                // if (CanUseTrinket("Slimy Consumptive Organ", TopTrinket, BotTrinket))
                // {
                //     if (CDAvatarRemains <= GCD || BuffAvatarUp) 
                //     {
                //         CastTrinketByName("Slimy Consumptive Organ", TopTrinket, BotTrinket);
                //         return true;
                //     }
                // }

                //POTION
                if (Aimsharp.CanUseItem(usableitems) && usableitems != "None" && !UsePotion) 
                {
                    if (HasLust | TargetTimeToDie < 60) 
                    {
                        Aimsharp.Cast("MacroItemUse", true);
                        return true;
                    }
                }

                //Racial Powers
                if (RacialPower == "Orc" && Fighting) 
                {
                    if (Aimsharp.CanCast(BloodFury_SpellName(), "player")) 
                    {
                        Aimsharp.Cast(BloodFury_SpellName(), true);
                        return true;
                    }
                }

                if (RacialPower == "Troll" && Fighting) 
                {
                    if (Aimsharp.CanCast(Berserking_SpellName(), "player")) 
                    {
                        Aimsharp.Cast(Berserking_SpellName(), true);
                        return true;
                    }
                }

                if (RacialPower == "Bloodelf" && Fighting) 
                {
                    if (Aimsharp.CanCast(ArcaneTorrent_SpellName(), "player")) 
                    {
                        Aimsharp.Cast(ArcaneTorrent_SpellName());
                        return true;
                    }
                }

                if (RacialPower == "Lightforged Draenei" && Fighting) 
                {
                    if (Aimsharp.CanCast(LightsJudgment_SpellName(), "player")) 
                    {
                        Aimsharp.Cast(LightsJudgment_SpellName(), true);
                        return true;
                    }
                }

                if (RacialPower == "Dark Iron Dwarf" && Fighting) 
                {
                    if (Aimsharp.CanCast(Fireblood_SpellName(), "player")) 
                    {
                        Aimsharp.Cast(Fireblood_SpellName(), true);
                        return true;
                    }
                }

                if (RacialPower == "Mag'har Orc" && Fighting) 
                {
                    if (Aimsharp.CanCast(AncestralCall_SpellName(), "player")) 
                    {
                        Aimsharp.Cast(AncestralCall_SpellName(), true);
                        return true;
                    }
                }

                if (RacialPower == "Vulpera" && Fighting) 
                {
                    if (Aimsharp.CanCast(BagofTricks_SpellName(), "player")) 
                    {
                        Aimsharp.Cast(BagofTricks_SpellName(), true);
                        return true;
                    }
                }

            }

            
            //Phial of Serenity
            if (PlayerHealth < GetSlider("Auto Kyrian Phial @ HP%")) 
            {
                if (Aimsharp.CanUseItem(PhialofSerenity_SpellName())) 
                {
                    Aimsharp.Cast("MacroPotion", true);
                    return true;
                }
            }
        

            //actions+=/shield_slam,if=runeforge_the_wall_equipped
            if (Aimsharp.CanCast(ShieldSlam_SpellName(),"player") && runeforge_the_wall_equipped)
            {
                Aimsharp.Cast(ShieldSlam_SpellName());
                return true;
            }

            //actions+=/thunder_clap,if=runeforge_thunderlord_equipped&enemiesinmelee>1
            if (Aimsharp.CanCast(ThunderClap_SpellName(),"player") && runeforge_thunderlord_equipped && EnemiesInMelee > 1)
            {
                Aimsharp.Cast(ThunderClap_SpellName());
                return true;
            }

            //actions+=/charge,if=runeforge_reprisal_equipped
            if (runeforge_reprisal_equipped)
            {
                if (AutomaticCharge && Range >= 8 && Range <= 30 && Aimsharp.CanCast(Charge_SpellName(), "player") && !BuffShieldBlockUp && ShieldBlockCharges != 2)
                {
                    Aimsharp.Cast(Charge_SpellName());
                    return true;
                }

                if (!NoFocus && InterveneOn && Aimsharp.CanCast(Intervene_SpellName(), "player") && !BuffShieldBlockUp && ShieldBlockCharges != 2)
                {
                    Aimsharp.Cast("MacroInterveneFocus", true);
                    return true;
                }

                if (BuffRevengeUp && Aimsharp.CanCast(Revenge_SpellName(), "player"))
                {
                    Aimsharp.Cast(Revenge_SpellName());
                    return true;
                }

            }

            //actions+=/ignore_pain,if=rage.deficit<40*talent.booming_voice.enabled*cooldown.demoralizing_shout.ready
            if (Aimsharp.CanCast(IgnorePain_SpellName(), "player")) 
            {
                if ((RageDefecit < 40 * (TalentBoomingVoice ? 1 : 0) * (CDDemoralizingShoutReady ? 1 : 0)) || PlayerHealth <= GetSlider("Use Ignore Pain for survival @ HP%") && !IgnorePainUP) 
                {
                    Aimsharp.Cast(IgnorePain_SpellName());
                    return true;
                }
            }
        
            #region Mitigation

            //actions.mitigation=ignore_pain,if=rage>50&buff.ignore_pain.down
            if (Aimsharp.CanCast(IgnorePain_SpellName(), "player") && Rage > 50 && !IgnorePainUP)                
            {
                Aimsharp.Cast(IgnorePain_SpellName());
                return true;
            }
            

            //actions.mitigation+=/shield_block,if=(!talent.bolster.enabled|!buff.last_stand.up)&(charges_fractional>1.8|incoming_damage_5s)
            if (Aimsharp.CanCast(ShieldBlock_SpellName(),"player") && !BuffShieldBlockUp && (!TalentBolster | !BuffLastStandUp) && ShieldBlockCharges > 1.8 ) 
            {
                Aimsharp.Cast(ShieldBlock_SpellName());
                return true;
            }

            //actions.mitigation+=/demoralizing_shout,if=(target.within10|active_enemies>1)&((incoming_damage_5s>0.15*health.max|health.pct<30)|(!talent.booming_voice.enabled|rage.max-rage<40))
            if ((Range <= 10 | EnemiesInMelee >= 1) | (!TalentBoomingVoice | RageDefecit < 40) && Aimsharp.CanCast(DemoralizingShout_SpellName(), "player"))
            {
                Aimsharp.Cast(DemoralizingShout_SpellName());
                return true;
            }

            #endregion

            //actions+=/avatar
            if (Aimsharp.CanCast(Avatar_SpellName(), "player") && !NoCooldowns && TargetTimeToDie > 10) 
            {
                Aimsharp.Cast(Avatar_SpellName());
                return true;
            }

            //actions+=/ancient_aftershock
            if (CovenantNightFae && Aimsharp.CanCast(AncientAftershock_SpellName(), "player") && TargetTimeToDie > 4)
            {
                Aimsharp.Cast(AncientAftershock_SpellName());
                return true;
            }

            //actions.aoe = Spear_of_Bastion
            if (EnemiesInMelee >= 1 && CovenantKyrian && CDSpearReady && !NoCooldowns && TargetTimeToDie > 4)
            {
                Aimsharp.Cast("MacroBastion", true);
                return true;
            }

            //actions+=/conquerors_banner
            if (Aimsharp.CanCast(ConquerorsBanner_SpellName(), "player") && CovenantNecrolord && !NoCooldowns && TargetTimeToDie > 20)
            {
                Aimsharp.Cast(ConquerorsBanner_SpellName());
                return true;
            }

            //actions+=/shield_block,if=buff.shield_block.down
            if (Aimsharp.CanCast(ShieldBlock_SpellName(),"player") && !BuffShieldBlockUp) 
            {
                Aimsharp.Cast(ShieldBlock_SpellName());
                return true;
            }


            #region AOE
            if (EnemiesInMelee >= 3) 
            {                    
                //actions.aoe+=/ravager
                if (Aimsharp.CanCast(Ravager_SpellName(), "player") && TargetTimeToDie > 6)
                {
                    Aimsharp.Cast("MacroRavageSelf");
                    return true;
                }

                //actions.aoe+=/dragon_roar
                if (Aimsharp.CanCast(DragonRoar_SpellName(), "player") && TargetTimeToDie > 4) 
                {
                    Aimsharp.Cast(DragonRoar_SpellName());
                    return true;
                }

                //actions.aoe = thunder_clap
                if (Aimsharp.CanCast(ThunderClap_SpellName(), "player")) 
                {
                    Aimsharp.Cast(ThunderClap_SpellName());
                    return true;
                }

                //actions.aoe+=/revenge
                if (Aimsharp.CanCast(Revenge_SpellName(), "player") && ((UseOnlyFreeRevenge && BuffRevengeUp) || !UseOnlyFreeRevenge) && Rage >= 40) 
                {
                    Aimsharp.Cast(Revenge_SpellName());
                    return true;
                }

                //actions.aoe+=/shield_slam
                if (Aimsharp.CanCast(ShieldSlam_SpellName(),"player")) 
                {
                    Aimsharp.Cast(ShieldSlam_SpellName());
                    return true;
                }
                
                //actions.aoe+=/shockwave
                if (!NoCooldowns && EnemiesInMelee >= 2 && Aimsharp.CanCast(Shockwave_SpellName(), "player") && CastingRemaining < KickValue && (IsChannelingTar || IsInterruptable || !IsInterruptable)) 
                {
                    Aimsharp.Cast(Shockwave_SpellName());
                    return true;
                }
            }
            
            #endregion

            #region Single Target
            
            //actions.st+=/ravager
            if (Aimsharp.CanCast(Ravager_SpellName(), "player") && TargetTimeToDie > 6)
            {
                Aimsharp.Cast("MacroRavageSelf");
                return true;
            }

            //actions.st+=/dragon_roar
            if (Aimsharp.CanCast(DragonRoar_SpellName(), "player") && TargetTimeToDie > 4) 
            {
                Aimsharp.Cast(DragonRoar_SpellName());
                return true;
            }

            //actions.st+=/shield_slam,if=buff.shield_block.up
            if (Aimsharp.CanCast(ShieldSlam_SpellName(), "player") && BuffShieldBlockUp) 
            {
                Aimsharp.Cast(ShieldSlam_SpellName());
                return true;
            }

            //actions.st+=/thunder_clap,if=(spell_targets.thunder_clap>1|cooldown.shield_slam.remains)&talent.unstoppable_force.enabled&buff.avatar.up
            if (Aimsharp.CanCast(ThunderClap_SpellName(), "player")) 
            {
                if ((EnemiesInMelee > 1 | !CDShieldSlamReady) && BuffAvatarUp && TalentUnstoppableForce) 
                {
                    Aimsharp.Cast(ThunderClap_SpellName());
                    return true;
                }
            }

            //actions.st+=/shield_slam
            if (Aimsharp.CanCast(ShieldSlam_SpellName()))
            {
                Aimsharp.Cast(ShieldSlam_SpellName());
                return true;
            }
            
            //actions.st+=/shockwave
            if (!NoCooldowns && Aimsharp.CanCast(Shockwave_SpellName(), "player") && CastingRemaining < KickValue && (IsChannelingTar || IsInterruptable || !IsInterruptable)) 
            {
                Aimsharp.Cast(Shockwave_SpellName());
                return true;
            }

            //actions.st+=/condemn
            if ((Rage >= 20 && TargetHealth <= 20 ) || (CovenantVenthyr && TargetHealth >= 80 )) 
            {
                
                if (Aimsharp.CanCast(Execute_SpellName(), "player")) 
                {
                    Aimsharp.Cast(Execute_SpellName());
                    return true;
                }
            }

            //actions.st+=/revenge,if=rage>=70
            if (Aimsharp.CanCast(Revenge_SpellName(), "player") && ((UseOnlyFreeRevenge && BuffRevengeUp) || !UseOnlyFreeRevenge) && Rage >= 70) 
            {
                Aimsharp.Cast(Revenge_SpellName());
                return true;
            }

            //actions.st+=/thunder_clap
            if (Aimsharp.CanCast(ThunderClap_SpellName(), "player")) 
            {
                Aimsharp.Cast(ThunderClap_SpellName());
                return true;
            }

            //actions.st+=/revenge
            if (Aimsharp.CanCast(Revenge_SpellName(), "player") && ((UseOnlyFreeRevenge && BuffRevengeUp) || !UseOnlyFreeRevenge)) 
            {
                Aimsharp.Cast(Revenge_SpellName());
                return true;
            }        

            //actions.st+=/devastate
            if (Aimsharp.CanCast(Devastate_SpellName(), "player")) 
            {
                Aimsharp.Cast(Devastate_SpellName());
                return true;
            }
            #endregion
            return false;
        }
            
        public override bool OutOfCombatTick()
        {    
            if (Aimsharp.CanCast(BattleShout_SpellName(), "player") && !Aimsharp.HasBuff(BattleShout_SpellName(), "player", false)) 
            {
                Aimsharp.Cast(BattleShout_SpellName());
                return true;
            }
            return false;
        }

    }
}

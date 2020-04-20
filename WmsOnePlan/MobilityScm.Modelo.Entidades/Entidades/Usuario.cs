using System;
using System.Net.Mime;

namespace MobilityScm.Modelo.Entidades
{
    [Serializable]
    public class Usuario
    {
        public string LOGIN_ID { get; set; }

        public string ROLE_ID { get; set; }

        public string LOGIN_NAME { get; set; }

        public string LOGIN_TYPE { get; set; }

        public string LOGIN_STATUS { get; set; }

        public string LOGIN_PWD { get; set; }

        public string LOGIN_PWD_ALTERNATE { get; set; }

        public string LICENSE_SERIAL { get; set; }

        public string ENVIRONMENT { get; set; }

        public string GUI_LAYOUT { get; set; }

        public int? IS_LOGGED { get; set; }

        public DateTime? LAST_LOGGED { get; set; }

        public string DEFAULT_WAREHOUSE_ID { get; set; }

        public decimal? CONSOLIDATION_TERMINAL { get; set; }

        public string GENERATE_TASKS { get; set; }

        public string LOADING_GATE { get; set; }

        public string LINE_ID { get; set; }


        public string EMAIL { get; set; }

        public int? AUTHORIZER { get; set; }

        public int? IS_EXTERNAL { get; set; }

        public string RELATED_CLIENT { get; set; }

        public decimal? NOTIFY_LETTER_QUOTA { get; set; }

        public bool IS_SELECTED { get; set; }

        public string IMG { get; set; }

        public string loginId { get; set; }
        public string password { get; set; }
        public string roleId { get; set; }
        public string loginName { get; set; }
        public string loginType { get; set; }
        public string loginStatus { get; set; }
        public string loginPwd { get; set; }
        public string loginPwdAlternate { get; set; }
        public string licenseSerial { get; set; }
        public string environment { get; set; }
        public string guiLayout { get; set; }
        public string isLogged { get; set; }
        public string lastLogged { get; set; }
        public string defaultWarehouseId { get; set; }
        public int consolidationTerminal { get; set; }
        public string generateTasks { get; set; }
        public string loadingGate { get; set; }
        public string lineId { get; set; }
        public string swift3PlWarehouse { get; set; }
        public string email { get; set; }
        public int authorizer { get; set; }
        public int isExternal { get; set; }
        public string relatedClient { get; set; }
        public double? notifyLetterQuota { get; set; }
        public string distributionCenterId { get; set; }
        public int canRelocate { get; set; }
        public string linePosition { get; set; }
        public string spotColumn { get; set; }
        public string terminalIp { get; set; }
        public string externalUserLogin { get; set; }
        public string externalNameUser { get; set; }

        public int domainId { get; set; }
        public int DOMAIN_ID { get; set; }
        public ConfiguracionDeAmbiente SetupEnvironment { get; set; }
        public Dominio Domain { get; set; }
    }
}

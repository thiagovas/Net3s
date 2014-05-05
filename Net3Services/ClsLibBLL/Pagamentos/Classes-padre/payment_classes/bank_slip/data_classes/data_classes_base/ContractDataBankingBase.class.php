<?php    

	/**
	 * The abstract ContractDataBankingBase class defined here is
	 * a base class and contains all the basic functionality as well as
	 * basic methods involving contract between bank office and company. 
	 * 
     * 
     * In portuguese: Dados contratuais
     * 
	 * @package Intranet 
	 * @property integer $Quantity the value for intQuantity 
	 * @property float $UnitValue the value for fltUnitValue 
     * @property boolean $Accepted the value for blnAccepted 
	 * @property string $Currency the value for strCurrency 
     * @property string $Bank the value for strBank
	 * @property string $Branch the value for strBranch 
     * @property string $Account the value for strAccount
	 * @property string $DigitAccount the value for strDigitAccount
     */
     
    abstract class ContractDataBankingBase extends QBaseClass{
        
    	/**
    	 * Protected member variable that stores quantity value 
         * @var string strQuantity;
    	 */        
        
        protected $strQuantity;

    	/**
    	 * Protected member variable that stores unit value 
         * @var float fltUnitValue;
    	 */        
        
        protected $fltUnitValue;

    	/**
    	 * Protected member variable that stores accepted flag 
         * @var boolean blnAccepted;
    	 */        
        
        protected $blnAccepted;


    	/**
    	 * Protected member variable that stores currency name 
         * @var string strCurrency;
    	 */        
        
        protected $strCurrency;
        
        
    	/**
    	 * Protected member variable that stores bank number 
         * @var string strBranch;
    	 */        
        
        protected $strBank;        
        
    	/**
    	 * Protected member variable that stores bank branch number 
         * @var string strBranch;
    	 */        
        
        protected $strBranch;
        
    	/**
    	 * Protected member variable that stores bank account number 
         * @var string strAccount;
    	 */        
        
        protected $strAccount;
        
    	/**
    	 * Protected member variable that stores bank account digit number 
         * @var string strDigitAccount;
    	 */        
        
        protected $strDigitAccount;
        
    	/**
    	 * Protected member variable that stores logo name
         * @var string strLogo;
    	 */        
        
        protected $strLogo;        
                
        public function __construct($strBank, $strBranch, $strAccount) {

            try {
                $this->strBank = QBank::GetCode($strBank);
                $this->strBranch = $strBranch;
                $this->strAccount = $strAccount;
                $this->strDigitAccount = "";                
                $this->strCurrency = "R$";
                $this->blnAccepted = false;
                $this->strQuantity = "";
                $this->fltUnitValue = 0.0;
                $this->strLogo = $strBank;

            } catch (QCallerException $objExc) {
                $objExc->IncrementOffset();
                throw $objExc;
            }
        }        

        public function __get($strName) {
            
            switch ($strName) {
                case 'Bank': return $this->strBank;
                case 'Branch': return $this->strBranch;
                case 'Account': return $this->strAccount;
                case 'DigitAccount': return $this->strDigitAccount;
                case 'Currency': return $this->strCurrency;
                case 'Quantity': return $this->strQuantity;
                case 'UnitValue': return ($this->fltUnitValue);                
                case 'Accepted': return ($this->blnAccepted ? "S" : "N");
                case 'BankLogo': return sprintf("%s/bank_slip/logos/bank/%s.jpg", __IMAGE_CORE_ASSETS__ , QString::UnderscoreFromCamelCase($this->strLogo));

				default:
					try {
						return parent::__get($strName);
					} catch (QCallerException $objExc) {
						$objExc->IncrementOffset();
						throw $objExc;
					}                
            }
        }
        
        public function __set($strName, $mixValue) {
    
            try {
                switch ($strName) {
					// Sets the value for strBank
                    // In Brazilian Portuguese: Número do banco
					// @param string $mixValue
					// @return string                    
                    case 'Bank': return ($this->strBank = QType::Cast($mixValue, QType::String));
					// Sets the value for strBranch
                    // In Brazilian Portuguese: Número da agência bancária
					// @param string $mixValue
					// @return string                    
                    case 'Branch': return ($this->strBranch = QType::Cast($mixValue, QType::String));
					// Sets the value for strAccount
                    // In Brazilian Portuguese: Número da conta
					// @param string $mixValue
					// @return string                    
                    case 'Account': return ($this->strAccount = QType::Cast($mixValue, QType::String));
					// Sets the value for strDigitAccount
                    // In Brazilian Portuguese: Dígito da conta bancária 
					// @param string $mixValue
					// @return string                    
                    case 'DigitAccount': return ($this->strDigitAccount = QType::Cast($mixValue, QType::String));
					// Sets the value for intQuantity
                    // In Brazilian Portuguese: Quantidade
					// @param string $mixValue
					// @return integer                    
                    case 'Quantity': return ($this->strQuantity = QType::Cast($mixValue, QType::String));
					// Sets the value for fltUnitValue
                    // In Brazilian Portuguese: Valor unitário
					// @param string $mixValue
					// @return float
                    case 'UnitValue': return ($this->fltUnitValue = QType::Cast($mixValue, QType::Float));
					// Sets the value for strAccount
                    // In Brazilian Portuguese: Moeda
					// @param string $mixValue
					// @return string
                    case 'Currency': return ($this->strCurrency = QType::Cast($mixValue, QType::String));
					// Sets the value for blnAccepted
                    // In Brazilian Portuguese: Aceite 
					// @param string $mixValue
					// @return boolean
                    case 'Accepted': return ($this->blnAccepted = QType::Cast($mixValue, QType::Boolean));
                    
    				default:
    					try {
    						return (parent::__set($strName, $mixValue));
    					} catch (QCallerException $objExc) {
    						$objExc->IncrementOffset();
    						throw $objExc;
    					}                
                    
                    
                }
            } catch (QCallerException $objExc) {
                $objExc->IncrementOffset();
                throw $objExc;
            }
        }
        
    }
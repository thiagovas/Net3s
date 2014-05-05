<?php    
    require(__PAYMENT_CLASSES__ . '/bank_slip/data_classes/data_classes_base/ContractDataBankingBase.class.php');
	/**
	 * The ContractDataBankingBancoBrasil class defined here is
	 * a class that contains all the functionality of specific bank as well as
	 * specific methods involving contract between bank office and company. 
	 * 
     * 
     * In portuguese: dados contratuais
     * 
	 * @package Intranet
	 * @property string $Agreement the value for strAgreement
     * @property string $ContractNumber the value for strContractNumber
     * @property string $Porfolio the value for strPortfolio
     * @property string $Variation the value for strVariation	 
     */
     
    class ContractDataBankingBancoBrasil extends ContractDataBankingBase {
        
    	/**
    	 * Protected member variable that stores agreement number 
         * @var string strAgreement;
    	 */        
        
        protected $strAgreement;
        
    	/**
    	 * Protected member variable that stores contract number 
         * @var string strContract;
    	 */        
        
        protected $strContract;
        
    	/**
    	 * Protected member variable that stores portfolio number 
         * @var string strPortfolio;
    	 */        
        
        protected $strPortfolio;
        
    	/**
    	 * Protected member variable that stores variation portfolio number 
         * @var string strVariation;
    	 */        
        
        protected $strVariation;        
                
        public function __construct($strBranch, $strAccount) {
            return parent::__construct(QBank::BancoBrasil, $strBranch, $strAccount);
        }        
        
        protected function BankCodeGen() {
            $strFirstStep = substr($this->strBank, 0, 3);
            $strSecondStep = BankSlipBase::GetCheckDigitMod11($strFirstStep);
            return sprintf("%s-%s", $strFirstStep, $strSecondStep);
        }
        
        
        protected function BranchCodeGen() {
            return sprintf("%s-%s / %s-%s", 
                            BankSlipBancoBrasil::NumberFormating($this->strBranch, 5), 
                            BankSlipBase::GetCheckDigitMod11($this->strBranch), 
                            BankSlipBancoBrasil::NumberFormating($this->strAccount, 5), 
                            BankSlipBase::GetCheckDigitMod11($this->strAccount));                        
        }
        
        public function __get($strName) {
            
            switch ($strName) {
                case 'BankCode': return $this->BankCodeGen();
                case 'BranchCode': return $this->BranchCodeGen();
                case 'Agreement': return $this->strAgreement;
                case 'ContractNumber': return $this->strContract;
                case 'Portfolio': return $this->strPortfolio;
                case 'Variation': return $this->strVariation;
                
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
					// Sets the value for strAgreement
                    // In Brazilian Portuguese: Nъmero do convкnio
					// @param string $mixValue
					// @return string                    
                    case 'Agreement': return ($this->strAgreement = QType::Cast($mixValue, QType::String));
					// Sets the value for strContract 
                    // In Brazilian Portuguese: Nъmero do contrato
					// @param string $mixValue
					// @return string                    
                    case 'ContractNumber': return ($this->strContract = QType::Cast($mixValue, QType::String));
					// Sets the value for strPortfolio
                    // In Brazilian Portuguese: Nъmero da carteira
					// @param string $mixValue
					// @return string                    
                    case 'Portfolio': return ($this->strPortfolio = QType::Cast($mixValue, QType::String));
					// Sets the value for strVariation
                    // In Brazilian Portuguese: Variaзгo da carteira
					// @param string $mixValue
					// @return string                    
                    case 'Variation': return ($this->strVariation = QType::Cast($mixValue, QType::String));
                    
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
?>
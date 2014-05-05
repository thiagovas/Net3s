<?php
    require(__PAYMENT_CLASSES__ . '/bank_slip/data_classes/data_classes_base/BankSlipBase.class.php');
	/**
	 * 
     * First code from BBBoletoFree Project supported by Daniel |
     * William Schultz e Leandro Maniezo
     * More information about BoletoPhp Project: www.boletophp.com.br
     * 
     * In portuguese: boleto
     * 
	 * @package Intranet
     */
     
    class BankSlipBancoBrasil extends BankSlipBase {
        
        protected $strKind;        
        
        public function __construct() {
            parent::__construct();
            try {
                $this->intDeadlinePayment = 5;
            } catch (QCallerException $objExc) {
                $objExc->IncrementOffset();
                throw $objExc;
            }
           
        }
        
        protected function GetLine() {
            
            $intAgreementLength = strlen($this->objContractBanking->Agreement);
            $intValueLength = (17 - $intAgreementLength); 

        	$strAgreement = self::NumberFormating($this->objContractBanking->Agreement, $intAgreementLength, "0", self::Agreement);
        	$strOurNumber = self::NumberFormating($this->strOurNumber, $intValueLength);
            $strValue = self::NumberFormating($this->fltTotalValue, $intValueLength, "0", self::Value);
            $strData = sprintf("%s%s%s%s%06d%s%s%s",    
                                $this->objContractBanking->Bank, QCurrency::GetCode(QCurrency::Real), $this->MaturityFactor, 
                                $strValue, 0, $strAgreement, 
                                $strOurNumber, $this->objContractBanking->Portfolio);
            $strChkDigit = self::GetCheckDigitMod11($strData);
            $strLine = sprintf("%s%s%s%s%s%06d%s%s%s",    
                                            $this->objContractBanking->Bank, QCurrency::GetCode(QCurrency::Real), $strChkDigit, 
                                            $this->MaturityFactor, 
                                            $strValue, 0, $strAgreement, 
                                            $strOurNumber, $this->objContractBanking->Portfolio);
            return $strLine;
        }
        
        protected function OurNumberGen() {
            $intAgreementLength = strlen($this->objContractBanking->Agreement);
            $intValueLength = (17 - $intAgreementLength);

        	$strAgreement = self::NumberFormating($this->objContractBanking->Agreement, $intAgreementLength, "0", self::Agreement);
        	$strOurNumber = self::NumberFormating($this->strOurNumber, $intValueLength);
            
            if ($intAgreementLength == 8)            
                return sprintf("%s%s-%s", $strAgreement, $strOurNumber, self::GetCheckDigitMod11($strAgreement.$strOurNumber));
            else
                return sprintf("%s%s", $strAgreement, $strOurNumber);
        }
        
        public function TypeableLineGen() {
            // Position	Content
            // 1 to 3   Bank Number Id
            // 4        Currency Code - 9 for Brazilian Real
            // 5        Bar Code Check Digit
            // 6 to 19  Value (12 integers and 2 decimals)
            // 20 to 44 Free Filds defined by each bank
            
            $strLine = $this->GetLine();
        
            // 1. Field - compose by bank code, currency code, five first positions by free field
            // check digit for this field
            $p1 = substr($strLine, 0, 4);
            $p2 = substr($strLine, 19, 5);
            $p3 = self::GetCheckDigitMod10("$p1$p2");
            $p4 = "$p1$p2$p3";
            $p5 = substr($p4, 0, 5);
            $p6 = substr($p4, 5);
            $strField1 = "$p5.$p6";
        
            // 2. Field - compose by positions 6 to 15 of free field
            // e check digit of this field
            $p1 = substr($strLine, 24, 10);
            $p2 = self::GetCheckDigitMod10($p1);
            $p3 = "$p1$p2";
            $p4 = substr($p3, 0, 5);
            $p5 = substr($p3, 5);
            $strField2 = "$p4.$p5";
        
            // 3. Field - compose by positions 16 to 25 of free field
            // e check digit of this field            
            $p1 = substr($strLine, 34, 10);
            $p2 = self::GetCheckDigitMod10($p1);
            $p3 = "$p1$p2";
            $p4 = substr($p3, 0, 5);
            $p5 = substr($p3, 5);
            $strField3 = "$p4.$p5";
        
            // 4. Field - bar code check digit
            $strField4 = substr($strLine, 4, 1);
        
            // 5. Field compose by document value, without leading zeros e no edition (no points and commas). 
            // For null values, representation must be 000 (three zeros inline).
            $strField5 = substr($strLine, 5, 14);
        
            return sprintf("%s %s %s %s %s", $strField1, $strField2, $strField3, $strField4, $strField5); 
        }        
                
        public static function NumberFormating($strNumber, $intLength, $strLeadingValue = "0", $strKind = self::General) {
            
            if ($strKind == self::Agreement)
                $strNumber = _cr($strNumber);
            elseif ($strKind == self::Value)
                $strNumber = number_format($strNumber, 2, '', '');
                
            return str_pad($strNumber, $intLength, $strLeadingValue, STR_PAD_LEFT);
        }
        
        
        public function __get($strName) {
            
            switch ($strName) {
                case 'Kind': return $this->strKind;
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
                    case 'Kind': return ($this->strKind = QType::Cast($mixValue, QType::String));
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

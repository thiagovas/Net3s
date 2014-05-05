<?php
	/**
	 * The abstract BankSlip class defined here is
	 * a base class and contains all the basic functionality as well as
	 * basic methods to handle relationships and index-based loading.
	 * 
     * First code from BoletoPhp Project
     * More information about BoletoPhp Project: www.boletophp.com.br
     * 
     * In portuguese: boleto
     * 
	 * @package Intranet
	 * @property 
     */
     
    abstract class BankSlipBase extends QBaseClass{
        
        const General = "General";
        const Value = "Value";
        const Agreement = "Agreement";
    
		/**
		 * Protected member variable that stores deadline for payment
		 * @var integer intDeadlinePayment
		 */
		protected $intDeadlinePayment;
        
		/**
		 * Protected member variable that stores bank slip fee
		 * @var float fltBankSlipFee
		 */
		protected $fltBankSlipFee;

		/**
		 * Protected member variable that stores maturity;
		 * @var datetime dttMaturity
		 */
		protected $dttMaturity;
        
		/**
		 * Protected member variable that stores bank slip value;
		 * @var float fltValue
		 */
		protected $fltValue;
        
		/**
		 * Protected member variable that stores bank slip value;
		 * @var float fltValue
		 */
		protected $fltTotalValue;        
        
		/**
		 * Protected member variable that stores bank slip discount;
		 * @var float fltDiscount
		 */
		protected $fltDiscount;
        
		/**
		 * Protected member variable that stores our number data
         * @var string strOurNumber 
		 */
		protected $strOurNumber;
        
		/**
		 * Protected member variable that stores document number data
         * @var string strDocumentNumber 
		 */        
        protected $strDocumentNumber;

		/**
		 * Protected member variable that stores processing date
         * @var datetime dttProcessingDate
		 */        
        
        protected $dttProcessingDate;
        
		/**
		 * Protected member variable that stores document date
         * @var datetime dttDocumentDate
		 */        
        
        protected $dttDocumentDate;
        
		/**
		 * Protected member variable that stores document kind
         * @var datetime strDocumentKind
		 */        
        
        protected $strDocumentKind;

		/**
		 * Protected member variable that stores bank slip information
         * @var array strInformationArray
		 */        
        
        protected $strInformationArray = array();
        
		/**
		 * Protected member variable that stores bank slip instruction
         * @var array strInstructionArray
		 */        
        
        protected $strInstructionArray = array();
        
        protected $objContractBanking;        
        
        public function __construct() {

            try {
                $this->intDeadlinePayment = 0;
            } catch (QCallerException $objExc) {
                $objExc->IncrementOffset();
                throw $objExc;
            }
           
        }
        
        protected function BarCodeGen(){
            
            $strLine = $this->GetLine();
            $strImage = '';
                
            $intThin = 1 ;
            $intWide = 3 ;
            $intHeight = 50 ;
            
            $strBarCodeArray = array();
        
            $strBarCodeArray[0] = "00110" ; //6
            $strBarCodeArray[1] = "10001" ; //17
            $strBarCodeArray[2] = "01001" ; //9
            $strBarCodeArray[3] = "11000" ; //24
            $strBarCodeArray[4] = "00101" ; //5
            $strBarCodeArray[5] = "10100" ; //20
            $strBarCodeArray[6] = "01100" ; //14
            $strBarCodeArray[7] = "00011" ; //3
            $strBarCodeArray[8] = "10010" ; //18
            $strBarCodeArray[9] = "01010" ; //10
            
            for ($intF1 = 9; $intF1 >= 0; $intF1--){ 
                for ($intF2 = 9; $intF2 >= 0; $intF2--){  
                    $intFinalFactor = ($intF1 * 10) + $intF2 ;
                    $strAuxText = "" ;
                    for ($i = 1; $i < 6; $i++)
                        $strAuxText .=  substr($strBarCodeArray[$intF1], ($i - 1), 1) . substr($strBarCodeArray[$intF2], ($i - 1), 1);
                    $strBarCodeArray[$intFinalFactor] = $strAuxText;
                }
            }
        
            /* Bar draw */
            
            $strImageModel = str_repeat("<img src='" . __IMAGE_CORE_ASSETS__ . "/bank_slip/barcode/%s.png' width='%s' height='%s' border='0' />", 4);
            $strParameterArray = array();
            for ($i = 0; $i < 4; $i++) {
                array_push($strParameterArray, (($i % 2 == 0) ? 'p' : 'b'));
                array_push($strParameterArray, $intThin);
                array_push($strParameterArray, $intHeight);
            }
            
            // Draw first step: Start sentinel
            $strImage = vsprintf($strImageModel, $strParameterArray);
            $strTextValue = ((strlen($strLine) % 2 != 0) ? ("0" . $strLine) : $strLine);
                        
            // Draw intermediate step: data
            while (strlen($strTextValue) > 0) {
                $intPosition = round(QString::LeftChars($strTextValue, 2));
                $strTextValue = QString::RightChars($strTextValue, 2);
                $strComparison = $strBarCodeArray[$intPosition];
                $strImageModel = str_repeat("<img src='" . __IMAGE_CORE_ASSETS__ . "/bank_slip/barcode/%s.png' width='%s' height='%s' border='0' />", 2);
                
                for ($k = 1; $k < 11; $k += 2){
                    $strParameterArray = array();

                    $intF1 = (substr($strComparison, ($k - 1), 1) == "0") ? $intThin : $intWide; 
                        
                    $intF2 = (substr($strComparison, $k, 1) == "0") ? $intThin : $intWide;
                        
                    for ($j = 0; $j < 2; $j++) {
                        array_push($strParameterArray, (($j % 2 == 0) ? 'p' : 'b'));
                        array_push($strParameterArray, (($j % 2 == 0) ? $intF1 : $intF2));
                        array_push($strParameterArray, $intHeight);
                    }
                    
                    $strImage .= vsprintf($strImageModel, $strParameterArray);
                }
        
            }
            
            $strImageModel = str_repeat("<img src='" . __IMAGE_CORE_ASSETS__ . "/bank_slip/barcode/%s.png' width='%s' height='%s' border='0' />", 3);
            $strParameterArray = array();
            $strSecondParameterArray = array($intWide, $intThin, 1);
            
            for ($i = 0; $i < 3; $i++) {
                array_push($strParameterArray, (($i % 2 == 0) ? 'p' : 'b'));
                array_push($strParameterArray, $strSecondParameterArray[$i]);
                array_push($strParameterArray, $intHeight);
            }
            
            // Draw last step: Final sentinel
            $strImage .= vsprintf($strImageModel, $strParameterArray);
            
            return $strImage;
        }
        
        protected function GetLine() {}
        
        protected function OurNumberGen() {}
        
        protected function TypeableLineGen() {}
        
		/**
		 * This one calculates past days since 1997-10-07 until $dttMaturity
		 * 
	 	* @param void
		 * @return integer
		 */        

        public function MaturityFactor() {
            $dttPastDate = new QDateTime("1997-10-07");
            $dtsDiff =  $this->dttMaturity->Difference($dttPastDate);
            return $dtsDiff->Days;
        }
        
		/**
		 * This one gets check digits for first, second and third
         * fields in typeable line
		 * 
		 * @param string $strNumber
		 * @return integer
		 */        
        
        public static function GetCheckDigitMod10($strNumber) { 
        	
            $intTotalNumber = 0;
        	$intFactor = 2;
         
        	for ($i = strlen($strNumber); $i > 0; $i--) {
        		$strNumbersArray[$i] = substr($strNumber, $i - 1, 1);
        		$strPartialArray[$i] = $strNumbersArray[$i] * $intFactor;
        		$intTotalNumber .= $strPartialArray[$i];
        		$intFactor = (($intFactor == 2) ? 1 : 2);
        	}
        	
        	$intSum = 0;
        	for ($i = strlen($intTotalNumber); $i > 0; $i--) {
        		$strNumbersArray[$i] = substr($intTotalNumber, $i - 1, 1);
        		$intSum += $strNumbersArray[$i]; 
        	}
        	$intRest = $intSum % 10;
        	$intDigit = 10 - $intRest;
        	if ($intRest == 0)
        		$intDigit = 0;       	
        
        	return $intDigit;
        }
        
		/**
		 * This one gets check digits for first, second and third
         * fields in typeable line
		 * 
		 * @param string $strNumber
         * @param integer $intBase, default value: 9
         * @param integer $intRest, default value: 0
		 * @return integer
		 */         
        
        public static function GetCheckDigitMod11($strNumber, $intBase = 9, $intRest = 0) {
        	$intSum = 0;
        	$intFactor = 2; 
        	for ($i = strlen($strNumber); $i > 0; $i--) {
        		$strNumbersArray[$i] = substr($strNumber, $i - 1, 1);
        		$strPartialArray[$i] = $strNumbersArray[$i] * $intFactor;
        		$intSum += $strPartialArray[$i];
        		if ($intFactor == $intBase)
        			$intFactor = 1;
        		$intFactor++;
        	}
        	if ($intRest == 0) {
        		$intSum *= 10;
        		$intDigit = $intSum % 11;
        		
        		if ($intDigit == 10)
        			$intDigit = "X";
        
        		if (strlen($strNumber) == "43")
        			if ($intDigit == "0" || $intDigit == "X" || $intDigit > 9)
        					$intDigit = 1;
                            
        		return $intDigit;
        	}
        	elseif ($intRest == 1){
        		$intRest = $intSum % 11;
        		return $intRest;
        	}
        }

		/**
		 * This one returns instruction array on formatted html string
		 * 
	 	* @param void
		 * @return string
		 */        

        public function GetInstructions() {
            $strInstructions = "";
            foreach ($this->strInstructionArray as $strInstruction)
                $strInstructions .= sprintf("<p>%s</p>%s", $strInstruction, chr(13));
            return $strInstructions;
        }
        
        /**
		 * This set instruction array with new instruction
		 * 
	 	 * @param string $strInstruction
		 */        

        public function AddInstruction($strInstruction) {
        	array_push($this->strInstructionArray, $strInstruction);
        }
        
		/**
		 * This one gets complete information about drawee 
		 * 
	 	* @param void
		 * @return string
		 */        

        public function GetDraweeInformation() {
            return sprintf("<p>%s</p><p>%s</p><p>%s</p>", $this->strDrawee, $this->strAddress, $this->strAddressComplement);
        }          
        
        public function __get($strName) {
            
            switch ($strName) {
                case 'DeadlinePayment': return $this->intDeadlinePayment;                
                case 'BankSlipFee': return $this->fltBankSlipFee;
                case 'Maturity': return $this->dttMaturity;
                case 'MaturityFactor': return $this->MaturityFactor();
                case 'Value': return $this->fltValue;
                case 'TotalValue': return $this->fltTotalValue;
                case 'Discount': return $this->fltDiscount;                
                case 'DocumentNumber': return $this->strDocumentNumber;                
                case 'ProcessingDate': return $this->dttProcessingDate;                
                case 'DocumentDate': return $this->dttDocumentDate;
                case 'Information': return $this->strInformationArray;                
                case 'BarCode': return $this->BarCodeGen();
                case 'ContractBanking': return $this->objContractBanking;
                case 'TypeableLine': return $this->TypeableLineGen();
                case 'OurNumber': return $this->OurNumberGen();
                case 'Instruction': return $this->GetInstructions();
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
    
            switch ($strName) {
                case 'DeadlinePayment': return ($this->intDeadlinePayment = QType::Cast($mixValue, QType::Integer));                
                case 'BankSlipFee': return ($this->fltBankSlipFee = QType::Cast($mixValue, QType::Float));
                case 'Maturity': return ($this->dttMaturity = QType::Cast($mixValue, QType::DateTime));
                case 'Value': return ($this->fltValue = QType::Cast($mixValue, QType::Float));
                case 'TotalValue': return ($this->fltTotalValue = QType::Cast($mixValue, QType::Float));
                case 'Discount': return ($this->fltDiscount = QType::Cast($mixValue, QType::Float));
                case 'DocumentNumber': return ($this->strDocumentNumber = QType::Cast($mixValue, QType::String));
                case 'ProcessingDate': return ($this->dttProcessingDate = QType::Cast($mixValue, QType::DateTime));
                case 'DocumentDate': return ($this->dttDocumentDate = QType::Cast($mixValue, QType::DateTime));
                case 'ContractBanking': return ($this->objContractBanking = QType::Cast($mixValue, "ContractDataBankingBase"));
                case 'Information': return (array_push($this->strInformationArray, QType::Cast($mixValue, QType::String)));
                case 'Instruction': return (array_push($this->strInstructionArray, QType::Cast($mixValue, QType::String)));
                case 'OurNumber': return ($this->strOurNumber = QType::Cast($mixValue, QType::String));
				default:
					try {
						return (parent::__set($strName, $mixValue));
					} catch (QCallerException $objExc) {
						$objExc->IncrementOffset();
						throw $objExc;
					}
            }
        }
    
    }    

?>

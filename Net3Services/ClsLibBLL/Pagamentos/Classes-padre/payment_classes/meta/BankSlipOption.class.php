<?php
	/**
	 * The BankSlipOption class defined here contains any
	 * customized code for the PaymentOption class in the
	 * Payment Model.
	 * 
	 * @package Intranet
	 * @subpackage DataObjects
	 * 
	 */
	class BankSlipOption extends PaymentOption {

        public function __construct(){
            try {
                $this->strCode = PaymentOption::BankSlip;
                $this->strName = QApplication::Translate("Bank Slip");
                $this->strIcon = "";
                $this->blnHasAdvancedPanel = false;

            } catch (QCallerException $objExc) {
                $objExc->IncrementOffset();
                throw $objExc;
            }            
        }        
        
		/**
		 * Override method to perform a property "Set"
		 * This will set the property $strName to be $mixValue
		 *
		 * @param string $strName Name of the property to set
		 * @param string $mixValue New value of the property
		 * @return mixed
		 */
        public function __set($strName, $mixValue) {
			switch ($strName) {
				default:
					try {
						return (parent::__set($strName, $mixValue));
					} catch (QCallerException $objExc) {
						$objExc->IncrementOffset();
						throw $objExc;
					}
			}
		}
        
		/**
		 * Override method to perform a property "Get"
		 * This will get the value of $strName
		 *
		 * @param string $strName Name of the property to get
		 * @return mixed
		 */        
        public function __get($strName) {
            
            switch ($strName) {
				default:
					try {
						return parent::__get($strName);
					} catch (QCallerException $objExc) {
						$objExc->IncrementOffset();
						throw $objExc;
					}
            }
        }        
	}
    
?>
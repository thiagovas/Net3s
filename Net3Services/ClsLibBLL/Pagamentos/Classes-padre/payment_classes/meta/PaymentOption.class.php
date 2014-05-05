<?php
	/**
	 * The abstract PaymentOption class defined here is
	 * contains all the basic type functionality as well as
	 * basic methods to handle payment options.
	 * 
	 * @package Intranet
	 * @property string $Code the value for strCode
	 * @property string $Name the value for strName
	 * @property string $Icon the value for strIcon
	 * @property boolean $HasAdvancedPanel the value for blnHasAdvancedPanel
	 */
	abstract class PaymentOption {
		protected $strCode;
		protected $strName;
		protected $strIcon;
		protected $blnHasAdvancedPanel;
        
        const BankSlip      = 'bank_slip';
        const CreditCard    = 'credit_card';
        const PayPal        = 'paypal';
        const PagSeguro     = 'pagseguro';
        
        public function __construct(){
            $this->strCode = "";
            $this->strName = "";
            $this->strIcon = "";
            $this->blnHasAdvancedPanel = false;
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
				case 'Code':
					try {
						return ($this->strCode = QType::CastConstTo($mixValue, 'PaymentOption'));
					} catch (QCallerException $objExc) {
						$objExc->IncrementOffset();
						throw $objExc;
					}
				case 'Name':
					try {
						return ($this->strName = QType::Cast($mixValue, QType::String));
					} catch (QCallerException $objExc) {
						$objExc->IncrementOffset();
						throw $objExc;
					}
				case 'Icon':
					try {
						return ($this->strIcon = QType::Cast($mixValue, QType::String));
					} catch (QCallerException $objExc) {
						$objExc->IncrementOffset();
						throw $objExc;
					}                    
				case 'HasAdvancedPanel':
					try {
						return ($this->blnHasAdvancedPanel = QType::Cast($mixValue, QType::Boolean));
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
				// Gets the value for strCode
				// @return string                
                case 'Code': return $this->strCode;
				// Gets the value for strName
				// @return string                                
                case 'Name': return $this->strName;
				// Gets the value for strIcon
				// @return string                                
                case 'Icon': return $this->strIcon;
				// Gets the value for blnHasAdvancedPanel
				// @return boolean                                
                case 'HasAdvancedPanel': return $this->blnHasAdvancedPanel;               
            }
        }
	}
    
?>
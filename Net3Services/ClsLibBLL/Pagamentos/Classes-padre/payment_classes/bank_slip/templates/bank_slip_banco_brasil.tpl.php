<div id="container">
    <!-- Protocolo de Entrega -->
    <? if ($this->bscBankSlip->PrintDraweeHeader) { ?>
    <div class="drawee header">
        <ul class="bank_info">
            <li class="bank_logo"><img src="<?=$this->bscBankSlip->Contract->BankLogo ?>" /></li>
            <li class="bank_code"><?=$this->bscBankSlip->Contract->BankCode ?></li>
            <li class="receipt"><span><?=$this->bscBankSlip->TypeableLine ?></span>Recibo de Entrega</li>
        </ul>    
        <ul>
            <li>
                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
                <label>Cedente</label>
                <p><?=$this->bscBankSlip->Transferor->Name ?> - <?=$this->bscBankSlip->Transferor->DocumentKind ?>: <?=$this->bscBankSlip->Transferor->Document ?></p>
            </li>
            <li class="top_right">
                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
                <label>Ag&ecirc;ncia / C&oacute;digo Cedente</label>
                <p><?=$this->bscBankSlip->Contract->BranchCode ?></p>
            </li>
        </ul>
        <ul>
            <li>
                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
                <label>Sacado</label>
                <p><?=$this->bscBankSlip->Drawee->Name ?> - <?=$this->bscBankSlip->Drawee->DocumentKind ?>: <?=$this->bscBankSlip->Drawee->Document ?></p>
            </li>
            <li class="top_right">
                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
                <label>Nosso N&uacute;mero</label>
                <p><?=$this->bscBankSlip->OurNumber ?></p>
            </li>
        </ul>
        <ul>
            <li class="medium_field">
                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
                <label>Vencimento</label>
                <p><strong><?=$this->bscBankSlip->Maturity ?></strong></p>
            </li>
            <li class="medium_field">
                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
                <label>No. Documento</label>
                <p><?=$this->bscBankSlip->DocumentNumber ?></p>
            </li>
            <li class="small_field">
                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
                <label>Esp&eacute;cie</label>
                <p><?=$this->bscBankSlip->Kind ?></p>
            </li>
            <li class="small_field currency">
                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
                <label>Moeda</label>
                <p><?=$this->bscBankSlip->Contract->Currency ?></p>
            </li>
            <li class="top_right">
                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
                <label><strong>Valor do Documento</strong></label>
                <p><strong><?=_c($this->bscBankSlip->Value, "") ?></strong></p>
            </li>
        </ul>
        <ul>
            <li class="medium_field receive">
                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
                <p>Recebi(emos) o bloqueto com essas caracter&iacute;sticas.</p>
            </li>
            <li class="signature">
                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
                <label>Assinatura</label>
                <p>&nbsp;</p>
            </li>
            <li class="bank_use date">
                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
                <label>Data de Entrega</label>
                <p>&nbsp;</p>
            </li>
            <li class="bank_use name">
                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
                <label>Nome</label>
                <p>&nbsp;</p>
            </li>                    
        </ul>
        <ul class="payment_place">
            <li>
                <label>Local do Pagamento</label>
                <p>Pag&aacute;vel em qualquer banco at&eacute; o vencimento.</p>
            </li>
        </ul>                
    </div><!-- div.drawee.header -->
    <hr class="cutline" />
    <!-- Recibo do Sacado -->
    <? } ?>
    
    <div class="drawee middle">
        <ul class="bank_info">
            <li class="bank_logo"><img src="<?=$this->bscBankSlip->Contract->BankLogo ?>" /></li>
            <li class="bank_code"><?=$this->bscBankSlip->Contract->BankCode ?></li>
            <li class="receipt"><span><?=$this->bscBankSlip->TypeableLine ?></span>Recibo do Sacado</li>
        </ul>
        <div class="right_box">
			<ul class="right_side no_bottom_line">
	            <li id="company_logo">
	                <img src="<?=$this->bscBankSlip->Transferor->Logo ?>" />                      
	            </li>                
	            <li class="highlight">
	                <label><strong>Vencimento</strong></label>
	                <p><strong><?=$this->bscBankSlip->Maturity ?></strong></p>                           
	            </li>
	            <li>
	                <label>Ag&ecirc;ncia / C&oacute;digo Cedente</label>
	                <p><?=$this->bscBankSlip->Contract->BranchCode ?></p>
	            </li>
	            <li>
	                <label>Nosso N&uacute;mero</label>
	                <p><?=$this->bscBankSlip->OurNumber ?></p>
	            </li>
	            <li>
	                <label><strong>(=) Valor do Documento</strong></label>
	                <p><strong><?=_c($this->bscBankSlip->Value, "") ?></strong></p>
	            </li>
	            <li>
	                <label>(-) Desconto / Abatimento</label>
	                <p><?=($this->bscBankSlip->Discount ? $this->bscBankSlip->Discount : "&nbsp;") ?></p>
	            </li>
	            <li>
	                <label>(-) Outras Dedu&ccedil;&otilde;es</label>
	                <p><?=($this->bscBankSlip->AdditionalDiscount ? $this->bscBankSlip->AdditionalDiscount : "&nbsp;") ?></p>
	            </li>
	            <li>
	                <label>(+) Mora / Multa</label>
	                <p><?=$this->bscBankSlip->Penalty ? _c($this->bscBankSlip->Penalty, "") : "&nbsp;"?></p>
	            </li>
	            <li>
	                <label>(+) Outros Acr&eacute;scimos</label>
	                <p><?=$this->bscBankSlip->Interest ? _c($this->bscBankSlip->Interest, "") : "&nbsp;"?></p>
	            </li>
	            <li class="last">
	                <label>(=) Valor cobrado</label>
	                <p><?=_c($this->bscBankSlip->TotalValue, "")?></p>
	            </li>
	        </ul>
		</div><!-- .right_box-->
        <div class="left_box">
			<ul>
	            <li class="payment_local">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Local do Pagamento</label>
	                <p><strong>Pag&aacute;vel em qualquer banco at&eacute; o vencimento.</strong></p>
	            </li>
	            <li class="bank_use highlight">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Uso do Banco</label>
	                <p>&nbsp;</p>
	            </li>
	        </ul>
	        <ul>
	            <li class="transferor uppercase">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Cedente</label>
	                <p><?=$this->bscBankSlip->Transferor->Name ?> - <?=$this->bscBankSlip->Transferor->DocumentKind ?>: <?=$this->bscBankSlip->Transferor->Document ?></p>
	            </li>
	        </ul>
	        <ul>                    
	            <li class="uppercase">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Endere&ccedil;o do Cedente</label>
	                <p><?=$this->bscBankSlip->Transferor->Address ?></p>
	            </li>              
	        </ul>
	        <ul>
	            <li class="medium_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Data do Documento</label>
	                <p><?=$this->bscBankSlip->DocumentDate ?></p>
	            </li>
	            <li class="medium_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>No. Documento</label>
	                <p><?=$this->bscBankSlip->DocumentNumber ?></p>
	            </li>
	            <li class="small_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Esp&eacute;cie doc.</label>
	                <p><?=$this->bscBankSlip->Kind ?></p>
	            </li>
	            <li class="small_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Aceite</label>
	                <p><?=$this->bscBankSlip->Contract->Accepted ?></p>
	            </li>
	            <li class="small_field special_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Data Process.</label>
	                <p><?=$this->bscBankSlip->ProcessingDate ?></p>
	            </li>                    
	        </ul>                
	        <ul>
	            <li class="medium_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Carteira</label>
	                <p><?=$this->bscBankSlip->Contract->Portfolio ?></p>
	            </li>
	            <li class="small_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Esp&eacute;cie</label>
	                <p><?=$this->bscBankSlip->Kind ?></p>
	            </li>
	            <li class="medium_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Quantidade</label>
	                <p><?=($this->bscBankSlip->Quantity ? $this->bscBankSlip->Quantity : "&nbsp;")?></p>
	            </li>
	            <li class="small_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Valor</label>
	                <p>&nbsp;</p>
	            </li>                    
	        </ul>
	        <ul class="instruction">
	            <li>
	                <label>Instru&ccedil;&otilde;es de responsabilidade do cedente</label>
	                <?=$this->bscBankSlip->Instruction?>
	            </li>
	        </ul>
		</div><!-- .left_box -->           
        
        <ul class="drawee_data" style="clear: both;">
            <li>
                <label>Sacado: </label>
                <p><?=$this->bscBankSlip->Drawee->Name ?></p>
                <p><?=$this->bscBankSlip->Drawee->Address ?></p>
                <p>
                    <?=$this->bscBankSlip->Drawee->Zipcode ?> - <?=$this->bscBankSlip->Drawee->CityState ?> - 
                    <?=$this->bscBankSlip->Drawee->DocumentKind ?>: <?=$this->bscBankSlip->Drawee->Document ?>
                </p>
                <label class="guarantor">Sacador/Avalista: </label>
            </li>
        </ul>
        <ul class="form_footer">
            <li>
                <label><i><img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/autenticacao.gif" /></i></label>
                <span class="highlight">
                    Este recibo somente ter&aacute; validade com a autentica&ccedil;&atilde;o mec&acirc;nica ou acompanhado do recibo de pagamento
                    emitido pelo banco. <br />
                    Recebimento atrav&eacute;s do cheque no. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    do banco <br />
                    Esta quita&ccedil;&atilde;o s&oacute; ter&aacute; validade ap&oacute;s o pagamento do cheque acima pelo banco do sacado.
                </span>
            </li>
        </ul>
    </div>
    
    <hr class="cutline" />
    <!-- Ficha de Compensa&ccedil;&atilde;o -->
    
    <div class="drawee footer">
        <ul class="bank_info">
            <li class="bank_logo"><img src="<?=$this->bscBankSlip->Contract->BankLogo ?>" /></li>
            <li class="bank_code"><?=$this->bscBankSlip->Contract->BankCode ?></li>
            <li class="receipt"><span class="single"><?=$this->bscBankSlip->TypeableLine ?></span></li>
        </ul>
        <div class="left_box">
	        <ul>
	            <li>
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Local do Pagamento</label>
	                <p><strong>Pag&aacute;vel em qualquer banco at&eacute; o vencimento.</strong></p>
	            </li>
			</ul>
			<ul>
	            <li class="transferor uppercase">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Cedente</label>
	                <p><?=$this->bscBankSlip->Transferor->Name ?> - <?=$this->bscBankSlip->Transferor->DocumentKind ?>: <?=$this->bscBankSlip->Transferor->Document ?></p>
	            </li>
			</ul>
			<ul>
	            <li class="medium_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Data do Documento</label>
	                <p><?=$this->bscBankSlip->DocumentDate->__toString("DD/MM/YYYY") ?></p>
	            </li>
	            <li class="medium_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>No. Documento</label>
	                <p><?=$this->bscBankSlip->DocumentNumber ?></p>
	            </li>
	            <li class="small_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Esp&eacute;cie doc.</label>
	                <p><?=$this->bscBankSlip->Kind ?></p>
	            </li>
	            <li class="small_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Aceite</label>
	                <p><?=$this->bscBankSlip->Contract->Accepted ?></p>
	            </li>
	            <li class="small_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Data Process.</label>
	                <p><?=$this->bscBankSlip->ProcessingDate->__toString("DD/MM/YYYY") ?></p>
	            </li>
			</ul>
			<ul class="user_field">
				<li class="medium_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Carteira</label>
	                <p><?=$this->bscBankSlip->Contract->Portfolio ?></p>
	            </li>
	            <li class="small_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Esp&eacute;cie</label>
	                <p><?=$this->bscBankSlip->Contract->Currency ?></p>
	            </li>
	            <li class="medium_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Quantidade</label>
	                <p><?=($this->bscBankSlip->Quantity ? $this->bscBankSlip->Quantity : "&nbsp;")?></p>
	            </li>
	            <li class="small_field">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Valor</label>
	                <p>&nbsp;</p>
	            </li>    
				
			</ul>
			<ul class="instruction">
	            <li>
	                <label>Instru&ccedil;&otilde;es de responsabilidade do cedente</label>
	                <?=$this->bscBankSlip->Instruction?>
	            </li>
	        </ul>
		</div>
		<div class="right_box">
			<ul>
				<li class="highlight maturity_final">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label><strong>Vencimento</strong></label>
	                <p><strong><?=$this->bscBankSlip->Maturity ?></strong></p>                           
	            </li>
	            <li>
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>Nosso N&uacute;mero</label>
	                <p><?=$this->bscBankSlip->OurNumber ?></p>
	            </li>
	            <li class="right_box">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label><strong>(=) Valor do Documento</strong></label>
	                <p><strong><?=_c($this->bscBankSlip->Value, "")?></strong></p>
	            </li>
			</ul>
			<ul class="price_data user_field">
	            <li>
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>(-) Desconto / Abatimento</label>
	                <p><?=($this->bscBankSlip->Discount ? $this->bscBankSlip->Discount : "&nbsp;") ?></p>                           
	            </li>
	            <li>
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>(-) Outras Dedu&ccedil;&otilde;es</label>
	                <p><?=($this->bscBankSlip->AdditionalDiscount ? $this->bscBankSlip->AdditionalDiscount : "&nbsp;") ?></p>
	            </li>
	            <li>
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>(+) Mora / Multa</label>
	                <p><?=$this->bscBankSlip->Penalty ? _c($this->bscBankSlip->Penalty, "") : "&nbsp;"?></p>
	            </li>
	            <li>
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>(+) Outros Acr&eacute;scimos</label>
	                <p><?=$this->bscBankSlip->Interest ? _c($this->bscBankSlip->Interest, "") : "&nbsp;"?></p>
	            </li>
	            <li class="last">
	                <img src="<?=__IMAGE_CORE_ASSETS__?>/bank_slip/separator.png" />
	                <label>(=) Valor cobrado</label>
	                <p><?=_c($this->bscBankSlip->TotalValue, "")?></p>
	            </li>
	        </ul>	
		</div>

        <ul class="drawee_data">
            <li>
                <label>Sacado: </label>
                <p><?=$this->bscBankSlip->Drawee->Name ?></p>
                <p><?=$this->bscBankSlip->Drawee->Address ?></p>
                <p>
                    <?=$this->bscBankSlip->Drawee->Zipcode ?> - <?=$this->bscBankSlip->Drawee->CityState ?> - 
                    <?=$this->bscBankSlip->Drawee->DocumentKind ?>: <?=$this->bscBankSlip->Drawee->Document ?>
                </p>
                <label>Sacador/Avalista: </label>
            </li>
        </ul>
        <ul class="form_footer">
            <li class="barcode">
                <span><?=$this->bscBankSlip->BarCode ?></span>
                <label>Autentica&ccedil;&atilde;o Mec&acirc;nica</label><strong class="text">Ficha de Compensa&ccedil;&atilde;o</strong>
            </li>
        </ul>
    </div><!-- .drawee.footer -->
</div>
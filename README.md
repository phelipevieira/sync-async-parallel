# sync-async-parallel

Que tal desmistificarmos juntos o mundo procedural, paralelizado, síncrono, assíncrono e suas performances?

Antes de tudo precisamos definir os conceitos que iremos abordar:

<b>Serializado:</b>
</br>
Sequência de processos dependentes que devem ser executados por um programa com um propósito pré-definido.

<b>Paralelismo:</b>
</br>
Processos independentes executados de forma simultânea por um programa com um propósito pré-definido.

<b>Comunicação Síncrona:</b>
</br>
Transmissão/Processamento de dados que ocorrem em tempo real, ou seja, para cada requisição a resposta é imediata.

<b>Comunicação Assíncrona:</b>
</br>
Transmissão/Processamento de dados que ocorrem de forma atemporal, ou seja, para cada requisição a resposta tanto pode ser imediata, como pode não ser.

Tendo os conceitos bem definidos, podemos concluir que as abordagens procedurais e paralelizadas tratam do espaço onde os processos serão executados, 
já as comunicações síncronas e assíncronas se referem ao tempo que as interações serão realizadas.

<b>Vamos exemplificar?</b>

Vamos supor que existe um formigueiro, e as formigas deste formigueiro precisam transportar 1kg de açúcar que está a
50 metros de distância do lado de fora para o lado de dentro.
Vamos determinar que as formigas são equivalentes ao poder computacional e que cada formiga pesa 3mg, determinaremos 
também que cada formiga suporta transportar 50 vezes o seu peso, tomamos então como verdade que cada formiga possui 
a capacidade de transporte de 150mg.

Determinaremos também que a velocidade média de uma formiga é de 0,20 cm/s, ou seja, para cada formiga completar um 
ciclo de transporte de 50 metros indo descarregada, mais 50 metros vindo carregada com 150mg de açúcar gasta-se em 
média 834 minutos e que no formigueiro temos um total de 10 formigas.
O processo de execução consiste em chamar todas as formigas do formigueiro para ir buscar o açúcar até que ele seja 
totalmente transportado do ponto A ao ponto B.

<b>Exemplo de Lógica Procedural Síncrona:</b>
</br>
Nessa abordagem as formigas farão uma fila e para que cada formiga realize sua tarefa, é necessário que a formiga 
da vez conclua o seu ciclo de transporte.

<b>Exemplo de Lógica Procedural Assíncrona:</b>
</br>
Nessa abordagem as formigas farão uma fila e cada formiga fará sua tarefa de forma independente, ou seja, para que 
uma formiga inicie sua tarefa, não se faz necessário a espera da conclusão da tarefa outra formiga.

<b>Exemplo de Lógica Paralelizada Síncrona:</b>
</br>
Nessa abordagem as formigas são posicionadas uma ao lado da outra, todas saem juntas do formigueiro, todas voltam 
juntas ao formigueiro.

<b>Exemplo de Lógica Paralelizada Assíncrona:</b>
</br>
Nessa abordagem todas as formigas são posicionadas uma ao lado da outra, a largada é dada e cada formiga faz sua 
atividade de forma independente até que não haja mais açúcar a ser transportado.

## BAIXE O REPO E EXECUTE O PROJETO PARA ANALISAR OS RESULTADOS

É importante ressaltar que como o tempo de processamento de cada comando foi fixado obtivemos um resultado insignificante 
na execução procedural assíncrona, entretanto, o resultado seria diferente se o tempo de execução de cada comando fosse volátil.

Outros pontos super importantes que devo alertar é que:
</br>
"Não existe bala de prata." - Brooks

Não leia esse texto e saia alterando seus códigos de forma inconsequente, assim como:
</br>
"O parto de uma criança leva nove meses, não importa quantas mulheres sejam designadas." - Brooks

Existem atividades que possuem a necessidade de atuarem de forma procedural e síncrona, atente-se aos 
resultados e garanta a qualidade de seus ativos com o máximo de cobertura possível de testes de unidade e integração.

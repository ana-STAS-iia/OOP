#include <iostream>
#include <vector>

using namespace std;

class Cities {
public:
	virtual string classname() const {
		return "Cities";
	}

	virtual bool isA(string name) const {
		return "Cities" == name;
	}

	virtual ~Cities() {}
};

class RussianCity: public Cities {
public:
	virtual string classname() const override {
		return "RussianCity";
	}

	virtual bool isA(string name) const override {
		return ("RussianCity" == name) || Cities::isA(name);
	}

	virtual void Russians() {
		cout << "Russians live (" << classname() << ")\n";
	}

	~RussianCity() {
		cout << "~RussianCity\n";
	}
};

class Volgograd : public RussianCity {
public:
	string classname() const override {
		return "Volgograd";
	}

	bool isA(string name) const override {
		return ("Volgograd" == name) || RussianCity::isA(name);
	}

	~Volgograd() {
		cout << "~Volgograd()\n";
	}
};

class TurkishCity: public Cities {
public:
	virtual string classname() const override {
		return "TurkishCity";
	}

	virtual bool isA(string name) const override {
		return ("TurkishCity" == name) || Cities::isA(name);
	}

	virtual void Turks() {
		cout << "Turks live (" << classname() << ")\n";
	}

	~TurkishCity() {
		cout << "~TurkishCity\n";
	}
};

class Istanbul : public TurkishCity {
public:
	string classname() const override {
		return "Istanbul";
	}

	bool isA(string name) const override {
		return ("Istanbul" == name) || TurkishCity::isA(name);
	}

	~Istanbul() {
		cout << "~Istanbul()\n";
	}
};

int main() {
	
	vector<Cities*> cities(10);
	for (int i = 0; i < cities.size(); i++) {
		int random = rand() % 4;
		switch (random) {
		case 0: cities[i] = new RussianCity; break;
		case 1: cities[i] = new Volgograd; break;
		case 2: cities[i] = new TurkishCity; break;
		case 3: cities[i] = new Istanbul; break;
		}
	}
	
	cout << "Check classname() :\n";
	for (int i = 0; i < 10; i++) {
		if (cities[i]->classname() == "RussianCity" || cities[i]->classname() == "Volgograd") {
			((RussianCity*)cities[i])->Russians();
		}
		else if (cities[i]->classname() == "TurkishCity" || cities[i]->classname() == "Istanbul") {
			((TurkishCity*)cities[i])->Turks();
		}
	}

	cout << "\nCheck isA()\n";
	for (int i = 0; i < 10; i++) {
		if (cities[i]->isA("RussianCity")) {
			((RussianCity*)cities[i])->Russians();
		}
		else if (cities[i]->isA("TurkishCity")) {
			((TurkishCity*)cities[i])->Turks();
		}
	}

	cout << "\nCheck dynamic_cast<>:\n";
	for (int i = 0; i < 10; i++) {
		if (dynamic_cast<RussianCity*>(cities[i]) != NULL)
			dynamic_cast<RussianCity*>(cities[i]) ->Russians();
		else if (dynamic_cast<TurkishCity*>(cities[i]) != NULL)
			dynamic_cast<TurkishCity*>(cities[i])->Turks();
	}

	return 0;
}